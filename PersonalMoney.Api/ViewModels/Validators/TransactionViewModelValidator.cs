using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.Services;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    ///  Transaction view model validator
    /// </summary>
    /// <seealso cref="AbstractValidator{T}" />
    public class TransactionViewModelValidator : AbstractValidator<TransactionViewModel>
    {
        private readonly AppDbContext dbContext;
        private readonly UserResolverService userResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionViewModelValidator" /> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="userResolver">The user resolver.</param>
        public TransactionViewModelValidator(AppDbContext dbContext, UserResolverService userResolver)
        {
            this.dbContext = dbContext;
            this.userResolver = userResolver;

            RuleFor(c => c.Date).NotEmpty();
            RuleFor(c => c.Amount).NotEmpty().GreaterThan(0);
            RuleFor(c => c.Type).NotEmpty().IsInEnum();
            RuleFor(c => c.AccountId)
                .NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(c => c.AccountId)
                        .Must(CheckRecord<Account>)
                        .WithMessage("Invalid Account");

                    RuleFor(c => c.AccountId)
                        .NotEqual(c => c.ToAccountId)
                        .WithMessage("From and To Accounts should not be same");
                });

            RuleFor(c => c.IsDeleted).Equal(false);

            RuleFor(c => c.ToAccountId)
                .NotEmpty()
                .When(c => c.Type == TransactionType.Transfer)
                .DependentRules(() =>
                {
                    RuleFor(c => c.ToAccountId)
                        .Must(CheckRecord<Account>)
                        .When(c => c.Type == TransactionType.Transfer)
                        .WithMessage("Invalid To Account");

                    RuleFor(c => c.Tags)
                        .Must(c => c.Count <= 0)
                        .When(c => c.Type == TransactionType.Transfer)
                        .WithMessage("Tags not allowed in Transfer mode");

                    RuleFor(c => c.SubCategoryId)
                        .Empty()
                        .When(c => c.Type == TransactionType.Transfer)
                        .WithMessage("Sub category not allowed in Transfer mode");

                    RuleFor(c => c.PayeeId)
                        .Empty()
                        .When(c => c.Type == TransactionType.Transfer)
                        .WithMessage("Payee not allowed in Transfer mode");
                });

            RuleFor(c => c.SubCategoryId)
                .NotEmpty()
                .When(c => c.Type != TransactionType.Transfer)
                .DependentRules(() =>
                {
                    RuleFor(c => c.SubCategoryId)
                        .Must(CheckRecord<SubCategory>)
                        .WithMessage("Invalid To Sub category");
                });

            RuleFor(c => c.PayeeId)
                .NotEmpty()
                .When(c => c.Type != TransactionType.Transfer)
                .DependentRules(() =>
                {
                    RuleFor(c => c.PayeeId)
                        .Must(CheckRecord<Payee>)
                        .WithMessage("Invalid To Payee");
                });

            RuleFor(c => c.Notes)
                .MaximumLength(250);

            RuleFor(c => c.Tags)
                .Must(d => d.Count <= 5)
                .WithMessage("Maximum 5 tags allowed")
                .DependentRules(() =>
                {
                    RuleFor(c => c.Tags)
                        .Must(CheckTags)
                        .WithMessage("Invalid Tags");
                });
        }

        private bool CheckRecord<T>(int id) where T : UserModel
        {
            return dbContext
                .Set<T>()
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == userResolver.GetUserId())
                .Any(c => c.Id == id);
        }

        private bool CheckTags(ICollection<int> tags)
        {
            var records = dbContext
                .Tags
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == userResolver.GetUserId())
                .Count(c => tags.Contains(c.Id));

            return records == tags.Count;
        }
    }
}