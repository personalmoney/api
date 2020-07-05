using AutoMapper;
using MoneyManager.Api.Models;

namespace MoneyManager.Api.ViewModels.Mapper
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
            CreateMap<AccountTypeViewModel, AccountType>();

            //Domain to viewmodel
            CreateMap<AccountType, AccountTypeViewModel>()
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}