using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.ViewModels;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.Services.Transaction
{
    internal class TransactionService : BaseService<Models.Transaction, TransactionRequestModel>, ITransactionService
    {
        private readonly IMapper mapper;
        private readonly AppDbContext dataContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionService"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="dataContext">The database context</param>
        /// <param name="userResolver">The user resolver service</param>
        public TransactionService(IMapper mapper,
            AppDbContext dataContext,
            UserResolverService userResolver)
          : base(mapper, dataContext, userResolver)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
        }

        /// <inheritdoc />
        public new async Task<TransactionViewModel> Get(int id)
        {
            return await dataContext.Transactions
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == UserId)
                .ProjectTo<TransactionViewModel>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        /// <inheritdoc />
        public PagingResponse<TransactionViewModel> Get(TransactionSearchViewModel request)
        {
            var raw = dataContext.Transactions.FromSqlRaw(@"SELECT `t`.`AccountId`,`t`.`Amount`, `t`.`CreatedTime`, COALESCE(`t`.`Date`, '0001-01-01 00:00:00.000000') AS `c`,
`t`.`Id`, `t`.`IsDeleted`, `t`.`Notes`, `t`.`PayeeId`, `t`.`SubCategoryId`, `t`.`ToAccountId`, `t`.`Date`, `t`.`Number`, `t`.`Status`, `t`.`ToAmount`,
`t`.`Type`, `t`.`UpdatedTime`, `t`.`UserId`, getTotal({0},{1},t.date,t.AccountId,t.ToAccountId,t.Id) as Balance FROM `Transactions` AS `t`", request.AccountId, UserId);

            var dataQuery = AddFilters(request, raw);
            var countQuery = AddFilters(request, dataContext.Transactions);
            var response = PagingResponse(request, countQuery, dataQuery);

            return response;
        }

        private IQueryable<TransactionViewModel> AddFilters(TransactionSearchViewModel request, IQueryable<Models.Transaction> transactions)
        {
            return transactions
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == UserId)
                .Where(c => c.AccountId == request.AccountId || c.ToAccountId == request.AccountId)
                .OrderByDescending(c => c.Date)
                .ThenByDescending(c => c.Id)
                .ProjectTo<TransactionViewModel>(mapper.ConfigurationProvider);
        }

        /// <inheritdoc />
        public PagingResponse<TransactionRequestModel> GetModified(TransactionSearchViewModel request)
        {
            var query = dataContext.Transactions
                .Where(c => c.UpdatedTime > request.LastSyncTime)
                .Where(c => c.UserId == UserId)
                .ProjectTo<TransactionRequestModel>(mapper.ConfigurationProvider);

            var response = PagingResponse(request, query, query);

            return response;
        }

        /// <inheritdoc cref="BaseService{TModel,TViewModel}" />
        public override async Task<TransactionRequestModel> Update(int id, TransactionRequestModel model)
        {
            var tags = dataContext.TransactionTags
                .Where(c => c.TransactionId == model.Id)
                .ToList();

            if (tags.Count > 0)
            {
                var tagsToDelete = tags.Where(c => !model.TagIds.Contains(c.TagId)).ToList();
                dataContext.TransactionTags.RemoveRange(tagsToDelete);

                foreach (var tag in tags.Except(tagsToDelete))
                {
                    model.TagIds.Remove(tag.TagId);
                }
            }

            return await base.Update(id, model);
        }

        private static PagingResponse<T> PagingResponse<T>(PagingRequest request, IQueryable<T> countQuery, IQueryable<T> dataQuery)
        {
            var response = new PagingResponse<T>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalRecords = countQuery.Count(),
                Records = dataQuery
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
            };
            return response;
        }
    }
}