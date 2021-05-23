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
                .ForMember(dest => dest.UpdatedTime, source => source.UseDestinationValue())
                .ForMember(dest => dest.CreatedTime, source => source.UseDestinationValue());

            //Domain to viewmodel
            CreateMap<Tag, TagViewModel>();

            CreateMap<TransactionTag, TagViewModel>()
                .ForMember(dest => dest.Name, source => source.MapFrom(c => c.Tag.Name))
                .ForMember(dest => dest.Id, source => source.MapFrom(c => c.TagId));
        }
    }
}