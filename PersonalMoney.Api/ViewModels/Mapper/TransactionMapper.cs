using System;
using System.Linq;
using AutoMapper;
using PersonalMoney.Api.Helpers;
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
            CreateMap<TransactionRequestModel, Transaction>()
                .ForMember(dest => dest.Date, source => source.MapFrom(c => c.Date.ToUniversalTime()))
                .ForMember(dest => dest.Tags, source => source.MapFrom(c => c.TagIds.Select(d => new TransactionTag { TagId = d })))
                .ForMember(dest => dest.UpdatedTime, source => source.UseDestinationValue())
                .ForMember(dest => dest.CreatedTime, source => source.UseDestinationValue());

            //Domain to viewmodel
            CreateMap<Transaction, TransactionRequestModel>()
                .ForMember(dest => dest.Type, source => source.MapFrom(c => Enum.Parse<TransactionType>(c.Type)))
                .ForMember(dest => dest.TagIds, source => source.MapFrom(c => c.Tags.Select(tag => tag.TagId)));

            //Domain to viewmodel
            CreateMap<Transaction, TransactionViewModel>()
                .ForMember(dest => dest.Type, source => source.MapFrom(c => Enum.Parse<TransactionType>(c.Type)))
                .ForMember(dest => dest.AccountName, source => source.MapFrom(c => c.Account.Name))
                .ForMember(dest => dest.CategoryName, source => source.MapFrom(c => c.SubCategory.Category.Name))
                .ForMember(dest => dest.SubCategoryName, source => source.MapFrom(c => c.SubCategory.Name))
                .ForMember(dest => dest.PayeeName, source => source.MapFrom(c => c.Payee.Name));
        }
    }
}