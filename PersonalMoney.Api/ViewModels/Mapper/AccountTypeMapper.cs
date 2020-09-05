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
                .ForMember(dest => dest.NameLowerCase, source => source.MapFrom(c => c.Name!.ToLower()));

            //Domain to viewmodel
            CreateMap<AccountType, AccountTypeViewModel>()
                .ForMember(dest => dest.UpdateTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreateTime, source => source.MapFrom(c => c.CreatedTime));
        }
    }
}