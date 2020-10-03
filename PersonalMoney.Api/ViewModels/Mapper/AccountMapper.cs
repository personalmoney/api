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
                .ForMember(dest => dest.NameLowerCase, source => source.MapFrom(c => c.Name!.ToLower()))
                .ForMember(dest => dest.Type, source => source.MapFrom(c => c.AccountType))
                .ForMember(dest => dest.Balance, source => source.Ignore())
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());
            //Domain to viewmodel
            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.AccountType, source => source.MapFrom(c => c.Type))
                .ForMember(dest => dest.UpdatedTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreatedTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}