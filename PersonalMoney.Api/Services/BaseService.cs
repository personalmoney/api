using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.Services
{
    internal abstract class BaseService<ViewT, ViewModelT> where ViewT : TimeModel
    {
        private readonly IMapper mapper;
        private readonly IFireStoreService fireStore;
        protected abstract string CollectionName { get; }

        public BaseService(IMapper mapper, IFireStoreService fireStore)
        {
            this.mapper = mapper;
            this.fireStore = fireStore;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<ViewModelT>> Get()
        {
            var views = await fireStore.GetCollection<ViewT>(CollectionName);
            var viewModels = mapper.Map<IEnumerable<ViewModelT>>(views);
            return viewModels;
        }

        /// <inheritdoc />
        public async Task<ViewModelT> Get(string id)
        {
            var view = await fireStore.GetDocument<ViewT>(CollectionName, id);
            var viewModel = mapper.Map<ViewModelT>(view);
            return viewModel;
        }

        /// <inheritdoc />
        public async Task<ViewModelT> Create(ViewModelT model)
        {
            var document = mapper.Map<ViewT>(model);
            var result = await fireStore.AddDocument(document, CollectionName);
            return mapper.Map<ViewModelT>(result);
        }

        /// <inheritdoc />
        public async Task<ViewModelT> Update(string id, ViewModelT model)
        {
            var document = mapper.Map<ViewT>(model);
            var result = await fireStore.UpdateDocument(document, CollectionName);
            return mapper.Map<ViewModelT>(result);
        }

        /// <inheritdoc />
        public async Task Delete(string id)
        {
            await fireStore.SoftDeleteDocument(id, CollectionName);
        }
    }
}