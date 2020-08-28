using AutoMapper;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.AccountType
{
    internal class AccountTypeService : BaseService<Models.AccountType, AccountTypeViewModel>, IAccountTypeService
    {
        protected override string CollectionName { get; } = "accountTypes";

        public AccountTypeService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}