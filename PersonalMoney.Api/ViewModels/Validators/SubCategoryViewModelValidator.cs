using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.Category;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.ViewModels.Validators
{
    /// <summary>
    /// SubCategory ViewModel
    /// </summary>
    /// <seealso cref="NameValidator{TModel, TViewModel}" />
    public class SubCategoryViewModelValidator : NameValidator<Models.SubCategory, SubCategoryViewModel>
    {
        private readonly ICategoryService categoryService;

        /// <inheritdoc />
        public override string CollectionName { get; protected set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryViewModelValidator" /> class.
        /// </summary>
        /// <param name="fireStoreService">The fire store service.</param>
        /// <param name="categoryService">The category service.</param>
        public SubCategoryViewModelValidator(IFireStoreService fireStoreService, ICategoryService categoryService)
            : base(fireStoreService, 50)
        {
            this.categoryService = categoryService;

            RuleFor(c => c.CategoryId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .MaximumLength(50)
                .MustAsync(CheckCategory)
                .WithMessage(c => "Invalid Parent category");
        }

        private async Task<bool> CheckCategory(string categoryId, CancellationToken cancellationToken)
        {
            return await categoryService.Get(categoryId) != null;
        }
    }
}