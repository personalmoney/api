using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MoneyManager.Api.Services.FireStore;
using MoneyManager.Api.ViewModels;

namespace MoneyManager.Api.Services.AccountType
{
    internal class AccountTypeService : IAccountTypeService
    {
        private readonly IMapper mapper;
        private readonly IFireStoreService fireStore;
        private const string CollectionName = "accountTypes";

        public AccountTypeService(IMapper mapper, IFireStoreService fireStore)
        {
            this.mapper = mapper;
            this.fireStore = fireStore;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<AccountTypeViewModel>> Get()
        {
            var types = await fireStore.GetCollection<Models.AccountType>(CollectionName);
            var accountTypes = mapper.Map<IEnumerable<AccountTypeViewModel>>(types);
            return accountTypes;
        }

        /// <inheritdoc />
        public async Task<AccountTypeViewModel> Get(string id)
        {
            var type = await fireStore.GetDocument<Models.AccountType>(CollectionName, id);
            var accountTypes = mapper.Map<AccountTypeViewModel>(type);
            return accountTypes;
        }

        /// <inheritdoc />
        public async Task<AccountTypeViewModel> Create(AccountTypeViewModel model)
        {
            var document = mapper.Map<Models.AccountType>(model);
            var result = await fireStore.AddDocument(document, CollectionName);
            return mapper.Map<AccountTypeViewModel>(result);
        }

        /// <inheritdoc />
        public async Task<AccountTypeViewModel> Update(string id, AccountTypeViewModel model)
        {
            var document = mapper.Map<Models.AccountType>(model);
            var result = await fireStore.UpdateDocument(document, CollectionName);
            return mapper.Map<AccountTypeViewModel>(result);
        }

        /// <inheritdoc />
        public async Task Delete(string id)
        {
            await fireStore.DeleteDocument(id, CollectionName);
        }
    }
}