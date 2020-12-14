using System.Linq;
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
                .ForMember(dest => dest.Date, source => source.MapFrom(c => c.Date.ToUniversalTime()))
                .ForMember(dest => dest.Tags, source => source.MapFrom(c => c.Tags.Select(d => new TransactionTag { TagId = d })))
                .ForMember(dest => dest.UpdatedTime, source => source.Ignore())
                .ForMember(dest => dest.CreatedTime, source => source.Ignore());

            //Domain to viewmodel
            CreateMap<Transaction, TransactionViewModel>()
                .ForMember(dest => dest.Tags, source => source.MapFrom(c => c.Tags.Select(tag => tag.TagId)));
        }
    }
}