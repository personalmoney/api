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
                .ForMember(dest => dest.NameLowerCase, source => source.MapFrom(c => c.Name!.ToLower()));

            //Domain to viewmodel
            CreateMap<Tag, TagViewModel>()
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}