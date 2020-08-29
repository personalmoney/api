using AutoMapper;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.AccountType
{
    internal class AccountTypeService : BaseService<Models.AccountType, AccountTypeViewModel>, IAccountTypeService
    {
        public override string CollectionName { get; } = CollectionNames.AccountTypes;

        public AccountTypeService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}