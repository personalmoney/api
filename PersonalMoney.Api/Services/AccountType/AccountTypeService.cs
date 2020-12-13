using AutoMapper;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.AccountType
{
    internal class AccountTypeService : BaseService<Models.AccountType, AccountTypeViewModel>, IAccountTypeService
    {
        public AccountTypeService(IMapper mapper, AppDbContext dataContext,
            UserResolverService userResolver)
            : base(mapper, dataContext, userResolver)
        {
        }
    }
}