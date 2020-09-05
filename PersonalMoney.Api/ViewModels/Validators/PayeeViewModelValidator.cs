using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    ///  Payee ViewModel validator
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class PayeeViewModelValidator : NameValidator<Models.Payee, PayeeViewModel>
    {
        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.Payees;

        /// <summary>
        /// Initializes a new instance of the <see cref="PayeeViewModelValidator"/> class.
        /// </summary>
        /// <param name="fireStoreService">The fire store service.</param>
        public PayeeViewModelValidator(IFireStoreService fireStoreService)
            : base(fireStoreService, 50)
        {
        }
    }
}