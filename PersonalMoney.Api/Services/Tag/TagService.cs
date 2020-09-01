using AutoMapper;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Services.FireStore;
using PersonalMoney.Api.ViewModels;

namespace PersonalMoney.Api.Services.Tag
{
    internal class TagService : BaseService<Models.Tag, TagViewModel>, ITagService
    {
        /// <inheritdoc />
        public override string CollectionName { get; protected set; } = CollectionNames.Tags;

        public TagService(IMapper mapper, IFireStoreService fireStore)
            : base(mapper, fireStore)
        {
        }
    }
}