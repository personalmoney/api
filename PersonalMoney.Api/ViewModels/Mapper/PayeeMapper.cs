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
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());

            //Domain to viewmodel
            CreateMap<Payee, PayeeViewModel>();
        }
    }
}