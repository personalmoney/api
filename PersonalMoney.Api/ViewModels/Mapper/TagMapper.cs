using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// Tag Mapper
    /// </summary>
    /// <seealso cref="Profile" />
    public class TagMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TagMapper"/> class.
        /// </summary>
        public TagMapper()
        {
            //Viewmodel to domain
            CreateMap<TagViewModel, Tag>();

            //Domain to viewmodel
            CreateMap<Tag, TagViewModel>()
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}