using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Category
{
    /// <summary>
    /// Category service
    /// </summary>
    /// <seealso cref="BaseService{TModel, TViewModel}" />
    /// <seealso cref="ICategoryService" />
    public class CategoryService : BaseService<Models.Category, CategoryViewModel>, ICategoryService
    {
        private readonly IMapper mapper;

        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.Categories;

        private readonly string userId;
        private readonly FirestoreDb db;

        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryService" /> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="fireStore">The fire store.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="httpAccess">The HTTP access.</param>
        /// <exception cref="ArgumentException">Invalid user</exception>
        public CategoryService(IMapper mapper,
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
        public override async Task<IEnumerable<CategoryViewModel>> Get()
        {
            CollectionReference collectionRef = db.Collection(CollectionName);
            var query = collectionRef.WhereEqualTo("userId", userId)
                .WhereEqualTo("isDeleted", false);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();

            IList<CategoryViewModel> records = new List<CategoryViewModel>();

            foreach (var document in snapshot.Documents)
            {
                var category = mapper.Map<CategoryViewModel>(document.ConvertToWithId<Models.Category>());
                await PrepareChildren(collectionRef.Document(document.Id), category);
                records.Add(category);
            }

            return records;
        }

        /// <inheritdoc />
        public override async Task<IEnumerable<CategoryViewModel>> Get(DateTime? lastSyncTime)
        {
            CollectionReference collectionRef = db.Collection(CollectionName);
            var query = collectionRef.WhereEqualTo("userId", userId);
            if (lastSyncTime.HasValue)
            {
                query = query.WhereGreaterThanOrEqualTo("updateTime", lastSyncTime.Value.ToUniversalTime());
            }
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            IList<CategoryViewModel> records = new List<CategoryViewModel>();

            foreach (var document in snapshot.Documents)
            {
                var category = mapper.Map<CategoryViewModel>(document.ConvertToWithId<Models.Category>());
                records.Add(category);
            }

            return records;
        }

        /// <inheritdoc />
        public override async Task<CategoryViewModel> Get(string id)
        {
            var docRef = db.Collection(CollectionName).Document(id);

            var snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists)
            {
                return default;
            }

            var result = snapshot.ConvertToWithId<Models.Category>();
            if (result.IsDeleted)
            {
                return default;
            }
            if (!string.Equals(result.UserId, userId))
            {
                return default;
            }

            var category = mapper.Map<CategoryViewModel>(result);
            await PrepareChildren(docRef, category);

            return category;
        }

        private async Task PrepareChildren(DocumentReference docRef, CategoryViewModel category)
        {
            await foreach (var subCollection in docRef.ListCollectionsAsync())
            {
                await PrepareChildren(subCollection.ListDocumentsAsync(), category);
            }
        }

        private async Task PrepareChildren(IAsyncEnumerable<DocumentReference> documents, CategoryViewModel category)
        {
            await foreach (var childDocument in documents)
            {
                var snapshot = await childDocument.GetSnapshotAsync();
                PrepareChild(snapshot, category);
            }
        }

        private void PrepareChild(DocumentSnapshot snapshot, CategoryViewModel category)
        {
            var subCategory = snapshot.ConvertToWithId<Models.SubCategory>();
            if (subCategory.IsDeleted)
            {
                return;
            }

            var subCategoryViewModel = mapper.Map<SubCategoryViewModel>(subCategory);
            category.SubCategories.Add(subCategoryViewModel);
        }
    }
}