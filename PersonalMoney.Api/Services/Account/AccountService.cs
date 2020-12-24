using AutoMapper;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Account
{
    internal class AccountService : BaseService<Models.Account, AccountViewModel>, IAccountService
    {
        public AccountService(IMapper mapper, AppDbContext dataContext,
            UserResolverService userResolver)
            : base(mapper, dataContext, userResolver)
        {
        }
    }
}