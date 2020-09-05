using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// Payee Mapper
    /// </summary>
    /// <seealso cref="Profile" />
    public class PayeeMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PayeeMapper"/> class.
        /// </summary>
        public PayeeMapper()
        {
            //Viewmodel to domain
            CreateMap<PayeeViewModel, Payee>()
                .ForMember(dest => dest.NameLowerCase, source => source.MapFrom(c => c.Name!.ToLower()));

            //Domain to viewmodel
            CreateMap<Payee, PayeeViewModel>()
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}