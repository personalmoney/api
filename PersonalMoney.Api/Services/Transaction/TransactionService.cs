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
            var query = dataContext.Transactions
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == UserId)
                .OrderByDescending(c => c.Date)
                .ThenByDescending(c => c.Id)
                .ProjectTo<TransactionViewModel>(mapper.ConfigurationProvider);

            var response = PagingResponse(request, query);

            return response;
        }

        /// <inheritdoc />
        public PagingResponse<TransactionRequestModel> GetModified(TransactionSearchViewModel request)
        {
            var query = dataContext.Transactions
                .Where(c => c.UpdatedTime > request.LastSyncTime)
                .Where(c => c.UserId == UserId)
                .ProjectTo<TransactionRequestModel>(mapper.ConfigurationProvider);

            var response = PagingResponse(request, query);

            return response;
        }

        private static PagingResponse<T> PagingResponse<T>(PagingRequest request, IQueryable<T> query)
        {
            var response = new PagingResponse<T>
            {
                CurrentPage = request.CurrentPage,
                PageSize = request.PageSize,
                TotalRecords = query.Count(),
                Records = query
                    .Skip((request.CurrentPage - 1) * request.PageSize)
                    .Take(request.PageSize)
            };
            return response;
        }
    }
}