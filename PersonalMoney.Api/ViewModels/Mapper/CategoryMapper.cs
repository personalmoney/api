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
                .ForMember(dest => dest.NameLowerCase, source => source.MapFrom(c => c.Name!.ToLower()))
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());

            //Domain to viewmodel
            CreateMap<Category, CategoryViewModel>();
        }
    }
}