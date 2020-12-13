using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// SubCategory mapper
    /// </summary>
    /// <seealso cref="Profile" />
    public class SubCategoryMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubCategoryMapper"/> class.
        /// </summary>
        public SubCategoryMapper()
        {
            //Viewmodel to domain
            CreateMap<SubCategoryViewModel, SubCategory>()
                .ForMember(dest => dest.NameLowerCase, source => source.MapFrom(c => c.Name!.ToLower()))
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());

            //Domain to viewmodel
            CreateMap<SubCategory, SubCategoryViewModel>();
        }
    }
}