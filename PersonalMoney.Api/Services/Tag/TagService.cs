using AutoMapper;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Tag
{
    internal class TagService : BaseService<Models.Tag, TagViewModel>, ITagService
    {
        public TagService(IMapper mapper,
            AppDbContext dataContext,
            UserResolverService userResolver)
            : base(mapper, dataContext, userResolver)
        {
        }
    }
}