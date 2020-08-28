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
                .ForMember(dest => dest.Type, source => source.MapFrom(c => c.AccountType));

            //Domain to viewmodel
            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.AccountType, source => source.MapFrom(c => c.Type))
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}