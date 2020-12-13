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
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.Services.Transaction
{
    internal class TransactionService : BaseService<Models.Transaction, TransactionViewModel>, ITransactionService
    {
        private readonly IMapper mapper;
        private readonly string userId;
        private readonly FirestoreDb db;

        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.Transactions;

        public TransactionService(IMapper mapper,
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
        public async Task<PagingResponse<TransactionViewModel>> Get(TransactionSearchViewModel request)
        {
            CollectionReference collectionRef = db.Collection(CollectionNames.Transactions);
            var query = collectionRef.WhereEqualTo("userId", userId)
             .WhereEqualTo("isDeleted", false)
             .Limit(request.PageSize)
             .StartAfter(request.PageSize * request.CurrentPage);

            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            var records = snapshot.Documents.Select(c => c.ConvertToWithId<Models.Transaction>());
            var viewModels = mapper.Map<IEnumerable<TransactionViewModel>>(records);

            PagingResponse<TransactionViewModel> pagingResponse = new PagingResponse<TransactionViewModel>(viewModels)
            {
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage,
                TotalRecords = 200
            };
            return pagingResponse;
        }

        /// <inheritdoc />
        public async Task<PagingResponse<TransactionViewModel>> GetModified(TransactionSearchViewModel request)
        {
            CollectionReference collectionRef = db.Collection(CollectionNames.Transactions);
            var query = collectionRef.WhereEqualTo("userId", userId)
                .Limit(request.PageSize)
                .StartAfter(request.PageSize * request.CurrentPage);

            if (request.LastSyncTime.HasValue)
            {
                query = query.WhereGreaterThanOrEqualTo("updateTime", request.LastSyncTime.Value.ToUniversalTime());
            }
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            var records = snapshot.Documents.Select(c => c.ConvertToWithId<Models.Transaction>());
            var viewModels = mapper.Map<IEnumerable<TransactionViewModel>>(records);

            PagingResponse<TransactionViewModel> pagingResponse = new PagingResponse<TransactionViewModel>(viewModels)
            {
                PageSize = request.PageSize,
                CurrentPage = request.CurrentPage,
                TotalRecords = 200
            };
            return pagingResponse;
        }
    }
}