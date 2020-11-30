using AutoMapper;
using PersonalMoney.Api.Models;

namespace PersonalMoney.Api.ViewModels.Mapper
{
    /// <summary>
    /// Transaction mapper
    /// </summary>
    public class TransactionMapper : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionMapper"/> class.
        /// </summary>
        public TransactionMapper()
        {
            //Viewmodel to domain
            CreateMap<TransactionViewModel, Transaction>()
                .ForMember(dest => dest.AccountId, source => source.MapFrom(c => c.Account))
                .ForMember(dest => dest.ToAccountId, source => source.MapFrom(c => c.ToAccount))
                .ForMember(dest => dest.SubCategoryId, source => source.MapFrom(c => c.SubCategory))
                .ForMember(dest => dest.PayeeId, source => source.MapFrom(c => c.Payee))
                .ForMember(dest => dest.Date, source => source.MapFrom(c => c.Date))
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());

            //Domain to viewmodel
            CreateMap<Transaction, TransactionViewModel>()
                .ForMember(dest => dest.Account, source => source.MapFrom(c => c.AccountId))
                .ForMember(dest => dest.SubCategory, source => source.MapFrom(c => c.SubCategoryId))
                .ForMember(dest => dest.Payee, source => source.MapFrom(c => c.PayeeId))
                .ForMember(dest => dest.ToAccount, source => source.MapFrom(c => c.ToAccountId));
        }
    }
}