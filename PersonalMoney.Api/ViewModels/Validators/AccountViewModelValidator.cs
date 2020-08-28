﻿using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.AccountType;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Account View Model validator
    /// </summary>
    /// <seealso cref="NameValidator{TModel,TViewModel}" />
    public class AccountViewModelValidator : NameValidator<Models.Account, AccountViewModel>
    {
        private readonly IAccountTypeService accountTypeService;

        /// <inheritdoc />
        public override string CollectionName { get; } = CollectionNames.Accounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountViewModelValidator" /> class.
        /// </summary>
        /// <param name="fireStoreService">The fire store service.</param>
        /// <param name="accountTypeService">The account type service.</param>
        public AccountViewModelValidator(IFireStoreService fireStoreService, IAccountTypeService accountTypeService)
        : base(fireStoreService, 50)
        {
            this.accountTypeService = accountTypeService;

            RuleFor(c => c.IsActive)
                .NotNull();

            RuleFor(c => c.IncludeInBalance)
             .NotNull();

            RuleFor(c => c.AccountType)
             .NotEmpty()
             .MaximumLength(50);

            RuleFor(c => c)
                .MustAsync(CheckAccountType)
                .OverridePropertyName(c => c.AccountType)
                .WithMessage(c => "Invalid Account Type");
        }

        private async Task<bool> CheckAccountType(AccountViewModel viewModel, CancellationToken cancellationToken)
        {
            return await accountTypeService.Get(viewModel.AccountType) != null;
        }
    }
}