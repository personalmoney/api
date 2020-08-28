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
            CreateMap<CategoryViewModel, Category>();

            //Domain to viewmodel
            CreateMap<Category, CategoryViewModel>()
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}