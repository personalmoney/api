using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
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
            RuleFor(c => c.Account)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .Must(CheckRecord<Account>)
                .WithMessage("Invalid Account");

            RuleFor(c => c.IsDeleted).Equal(false);

            RuleFor(c => c.ToAccount)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .When(c => c.Type == Helpers.TransactionType.Transfer)
                .Must(CheckRecord<Account>)
                .WithMessage("Invalid To Account");

            RuleFor(c => c.SubCategory)
                .NotEmpty()
                .When(c => c.Type != Helpers.TransactionType.Transfer)
                .Must(CheckRecord<SubCategory>)
                .WithMessage("Invalid To Sub category");

            RuleFor(c => c.Payee)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .When(c => c.Type != Helpers.TransactionType.Transfer)
                .Must(CheckRecord<Payee>)
                .WithMessage("Invalid To Payee");

            RuleFor(c => c.Notes)
                .MaximumLength(250);

            RuleFor(c => c.Tags)
                .Cascade(CascadeMode.Stop)
                .Must(d => d.Count <= 5)
                .WithMessage("Maximum 5 tags allowed")
                .Must(CheckTags)
                .WithMessage("Invalid To Tags");
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
            return dbContext
                .SubCategories
                .AsNoTracking()
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == userResolver.GetUserId())
                .All(c => tags.Contains(c.Id));
        }
    }
}