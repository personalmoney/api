using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.Category;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.SubCategory
{
    /// <summary>
    /// Category service
    /// </summary>
    /// <seealso cref="BaseService{TModel, TViewModel}" />
    /// <seealso cref="ISubCategoryService" />
    public class SubCategoryService : BaseService<Models.SubCategory, SubCategoryViewModel>, ISubCategoryService
    {
        private readonly IMapper mapper;
        private readonly string userId;
        private readonly FirestoreDb db;

        /// <inheritdoc />
        public override string CollectionName { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="fireStore">The fire store.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="httpAccess">The HTTP access.</param>
        /// <exception cref="ArgumentException">Invalid user</exception>
        public SubCategoryService(IMapper mapper,
            IFireStoreService fireStore,
            IConfiguration configuration,
            IHttpContextAccessor httpAccess)
            : base(mapper, fireStore)
        {
            this.mapper = mapper;
            userId = httpAccess.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "user_id")!.Value;
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Invalid user");
            }
            db = FirestoreDb.Create(configuration["FireBaseId"]);
        }

        /// <inheritdoc />
        public Task<SubCategoryViewModel> Get(string categoryId, string id)
        {
            SetCollectionName(categoryId);
            return base.Get(id);
        }

        /// <inheritdoc />
        public override async Task<IEnumerable<SubCategoryViewModel>> Get(DateTime? lastSyncTime)
        {
            CollectionReference collectionRef = db.Collection(CollectionNames.Categories);
            var query = collectionRef.WhereEqualTo("userId", userId);
            if (lastSyncTime.HasValue)
            {
                query = query.WhereGreaterThanOrEqualTo("updateTime", lastSyncTime.Value.ToUniversalTime());
            }
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            IList<SubCategoryViewModel> records = new List<SubCategoryViewModel>();

            foreach (var document in snapshot.Documents)
            {
                if (lastSyncTime.HasValue)
                {
                    await PrepareChildren(collectionRef.Document(document.Id), records, lastSyncTime.Value);
                }
            }

            return records;
        }

        /// <inheritdoc />
        public override async Task<SubCategoryViewModel> Create(SubCategoryViewModel model)
        {
            SetCollectionName(model.CategoryId);
            var record = await base.Create(model);
            await UpdateCollectionTime(model.CategoryId);
            return record;
        }

        /// <inheritdoc />
        public override async Task<SubCategoryViewModel> Update(string id, SubCategoryViewModel model)
        {
            SetCollectionName(model.CategoryId);
            var record = await base.Update(id, model);
            await UpdateCollectionTime(model.CategoryId);
            return record;
        }

        /// <inheritdoc />
        public async Task Delete(string categoryId, string id)
        {
            SetCollectionName(categoryId);
            await base.Delete(id);
            await UpdateCollectionTime(categoryId);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<SubCategoryViewModel>> GetByCategoryId(string categoryId)
        {
            SetCollectionName(categoryId);
            return await base.Get();
        }

        private void SetCollectionName(string categoryId)
        {
            CollectionName = $"{CollectionNames.Categories}/{categoryId}/{CollectionNames.SubCategories}";
        }

        private Task UpdateCollectionTime(string categoryId)
        {
            return base.UpdateTime(categoryId, CollectionNames.Categories);
        }

        private async Task PrepareChildren(DocumentReference docRef, IList<SubCategoryViewModel> records, DateTime lastSyncTime)
        {
            await foreach (var subCollection in docRef.ListCollectionsAsync())
            {
                var data = await subCollection.WhereGreaterThan("updateTime", lastSyncTime.ToUniversalTime()).GetSnapshotAsync();
                PrepareChildren(data.Documents, records);
            }
        }

        private void PrepareChildren(IEnumerable<DocumentSnapshot> documents, ICollection<SubCategoryViewModel> records)
        {
            foreach (var document in documents)
            {
                var subCategory = document.ConvertToWithId<Models.SubCategory>();
                var subCategoryViewModel = mapper.Map<SubCategoryViewModel>(subCategory);
                records.Add(subCategoryViewModel);
            }
        }
    }
}