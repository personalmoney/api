using System;
using System.Threading.Tasks;
using AutoMapper;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.ViewModels;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.Services.Transaction
{
    internal class TransactionService : BaseService<Models.Transaction, TransactionViewModel>, ITransactionService
    {
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
        }

        /// <inheritdoc />
        public Task<PagingResponse<TransactionViewModel>> Get(TransactionSearchViewModel request)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public Task<PagingResponse<TransactionViewModel>> GetModified(TransactionSearchViewModel request)
        {
            throw new NotImplementedException();
        }
    }
}