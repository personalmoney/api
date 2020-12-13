using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// AccountType mapper
    /// </summary>
    /// <seealso cref="Profile" />
    public class AccountTypeMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountTypeMapper"/> class.
        /// </summary>
        public AccountTypeMapper()
        {
            //Viewmodel to domain
            CreateMap<AccountTypeViewModel, AccountType>()
                .ForMember(dest => dest.NameLowerCase, source => source.MapFrom(c => c.Name!.ToLower()))
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());

            //Domain to viewmodel
            CreateMap<AccountType, AccountTypeViewModel>();
        }
    }
}