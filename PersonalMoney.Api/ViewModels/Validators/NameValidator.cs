using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels.Base;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// Name Validator
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <seealso cref="AbstractValidator{TViewModel}" />
    public abstract class NameValidator<TModel, TViewModel> : AbstractValidator<TViewModel>
        where TModel : UserModel
        where TViewModel : NameViewModel
    {
        private readonly IFireStoreService fireStoreService;

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <value>
        /// The name of the collection.
        /// </value>
        public abstract string CollectionName { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameValidator{TModel, TViewModel}" /> class.
        /// </summary>
        /// <param name="fireStoreService">The fire store service.</param>
        /// <param name="maxLength">The maximum length.</param>
        protected NameValidator(IFireStoreService fireStoreService, int maxLength)
        {
            this.fireStoreService = fireStoreService;

            RuleFor(c => c.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(maxLength)
                .DependentRules(() =>
                {
                    RuleFor(c => c)
                        .MustAsync(CheckName)
                        .OverridePropertyName(c => c.Name)
                        .WithMessage(c => $"Record with the name {c.Name} already exists");
                });
        }

        private async Task<bool> CheckName(TViewModel model, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(model.Id))
            {
                return await fireStoreService.FindDocumentByName<TModel>(CollectionName, model.Name) == null;
            }
            else
            {
                return await fireStoreService.FindDocumentByName<TModel>(CollectionName, model.Name, model.Id) == null;
            }
        }
    }
}