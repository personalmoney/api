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
            CreateMap<TagViewModel, Tag>()
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());

            //Domain to viewmodel
            CreateMap<Tag, TagViewModel>();
        }
    }
}