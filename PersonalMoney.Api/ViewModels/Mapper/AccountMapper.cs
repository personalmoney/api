using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// Account Mapper
    /// </summary>
    /// <seealso cref="Profile" />
    public class AccountMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountMapper"/> class.
        /// </summary>
        public AccountMapper()
        {
            //Viewmodel to domain
            CreateMap<AccountViewModel, Account>()
                .ForMember(dest => dest.Balance, source => source.Ignore())
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());
            //Domain to viewmodel
            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.UpdatedTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreatedTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}