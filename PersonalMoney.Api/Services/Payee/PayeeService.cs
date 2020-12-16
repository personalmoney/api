using AutoMapper;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Payee
{
    internal class PayeeService : BaseService<Models.Payee, PayeeViewModel>, IPayeeService
    {
        public PayeeService(IMapper mapper, AppDbContext dataContext,
            UserResolverService userResolver)
            : base(mapper, dataContext, userResolver)
        {
        }
    }
}