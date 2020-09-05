using AutoMapper;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Payee
{
    internal class PayeeService : BaseService<Models.Payee, PayeeViewModel>, IPayeeService
    {
        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.Payees;

        public PayeeService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}