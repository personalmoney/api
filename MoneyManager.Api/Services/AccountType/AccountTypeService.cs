using System;
using System.Collections.Generic;
using AutoMapper;
using MoneyManager.Api.ViewModels;

namespace MoneyManager.Api.Services.AccountType
{
    internal class AccountTypeService : IAccountTypeService
    {
        private readonly IMapper mapper;

        public AccountTypeService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        /// <inheritdoc />
        public IEnumerable<AccountTypeViewModel> Get()
        {
            var types = new[]
            {
                new Models.AccountType {Id = 1, Name = "Wallets",IsActive = true,CreateTime = DateTime.Now,UpdateTime = DateTime.Now},
                new Models.AccountType {Id = 2, Name = "Credit card",IsActive = true,CreateTime = DateTime.Now,UpdateTime = DateTime.Now}
            };
            var accountTypes = mapper.Map<IEnumerable<AccountTypeViewModel>>(types);
            return accountTypes;
        }

        /// <inheritdoc />
        public AccountTypeViewModel Get(int id)
        {
            var type = new AccountTypeViewModel
            { Id = 1, Name = "Wallets", IsActive = true, CreateTime = DateTime.Now, UpdateTime = DateTime.Now };
            var accountTypes = mapper.Map<AccountTypeViewModel>(type);
            return accountTypes;
        }
    }
}