using AutoMapper;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Account
{
    internal class AccountService : BaseService<Models.Account, AccountViewModel>, IAccountService
    {
        public override string CollectionName { get; protected set; } = CollectionNames.Accounts;

        public AccountService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}