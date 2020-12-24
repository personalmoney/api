using System.Linq;
using AutoMapper;
using PersonalMoney.Api.Helpers;
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
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());
            //Domain to viewmodel
            CreateMap<Account, AccountViewModel>()
                .ForMember(dest => dest.UpdatedTime, source => source.MapFrom(c => c.UpdatedTime))
                .ForMember(dest => dest.CreatedTime, source => source.MapFrom(c => c.CreatedTime))
                .ForMember(c => c.Balance, source =>
                    source.MapFrom(d =>
                        d.InitialBalance +
                        (d.Transactions.Any() ? d.Transactions
                            .Where(c => !c.IsDeleted)
                            .Sum(c => c.Type == TransactionType.Deposit.ToString() ? c.Amount : c.Amount * -1) : 0)
                        +
                        (d.ToTransactions.Any() ? d.ToTransactions
                            .Where(c => !c.IsDeleted)
                            .Sum(c => c.Amount) : 0)));
        }
    }
}