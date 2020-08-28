using AutoMapper;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Account
{
    internal class AccountService : BaseService<Models.Account, AccountViewModel>, IAccountService
    {
        protected override string CollectionName { get; } = "accounts";

        public AccountService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}