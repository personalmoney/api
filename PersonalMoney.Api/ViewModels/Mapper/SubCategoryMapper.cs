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
            CreateMap<SubCategoryViewModel, SubCategory>();

            //Domain to viewmodel
            CreateMap<SubCategory, SubCategoryViewModel>()
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}