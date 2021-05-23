using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// Category mapper
    /// </summary>
    /// <seealso cref="Profile" />
    public class CategoryMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryMapper"/> class.
        /// </summary>
        public CategoryMapper()
        {
            //Viewmodel to domain
            CreateMap<CategoryViewModel, Category>()
                .ForMember(dest => dest.UpdatedTime, source => source.UseDestinationValue())
                .ForMember(dest => dest.CreatedTime, source => source.UseDestinationValue());

            //Domain to viewmodel
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.SubCategories, source => source.MapFrom(c => c.SubCategories));
        }
    }
}