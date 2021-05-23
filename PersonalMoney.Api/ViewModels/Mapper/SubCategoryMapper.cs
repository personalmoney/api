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
                .ForMember(dest => dest.UpdatedTime, source => source.UseDestinationValue())
                .ForMember(dest => dest.CreatedTime, source => source.UseDestinationValue());

            //Domain to viewmodel
            CreateMap<SubCategory, SubCategoryViewModel>();
        }
    }
}