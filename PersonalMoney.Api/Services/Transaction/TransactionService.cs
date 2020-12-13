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
        public TransactionService(IMapper mapper,
            AppDbContext dataContext,
            UserResolverService userResolver)
          : base(mapper, dataContext, userResolver)
        {
        }

        public Task<PagingResponse<TransactionViewModel>> Get(TransactionSearchViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<PagingResponse<TransactionViewModel>> GetModified(TransactionSearchViewModel request)
        {
            throw new NotImplementedException();
        }

        public Task<TransactionViewModel> Get(string id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new NotImplementedException();
        }
    }
}