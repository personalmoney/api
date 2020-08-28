﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PersonalMoney.Api.Models.Base;
using PersonalMoney.Api.Services.FireStore;

namespace PersonalMoney.Api.Services
{
    internal abstract class BaseService<TModel, TViewModel> : IBaseService<TModel, TViewModel> where TModel : TimeModel
    {
        private readonly IMapper mapper;
        private readonly IFireStoreService fireStore;
        public abstract string CollectionName { get; }

        protected BaseService(IMapper mapper, IFireStoreService fireStore)
        {
            this.mapper = mapper;
            this.fireStore = fireStore;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<TViewModel>> Get()
        {
            var views = await fireStore.GetCollection<TModel>(CollectionName);
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(views);
            return viewModels;
        }

        /// <inheritdoc />
        public async Task<TViewModel> Get(string id)
        {
            var view = await fireStore.GetDocument<TModel>(CollectionName, id);
            var viewModel = mapper.Map<TViewModel>(view);
            return viewModel;
        }

        /// <inheritdoc />
        public async Task<TViewModel> Create(TViewModel model)
        {
            var document = mapper.Map<TModel>(model);
            var result = await fireStore.AddDocument(document, CollectionName);
            return mapper.Map<TViewModel>(result);
        }

        /// <inheritdoc />
        public async Task<TViewModel> Update(string id, TViewModel model)
        {
            var document = mapper.Map<TModel>(model);
            var result = await fireStore.UpdateDocument(document, CollectionName);
            return mapper.Map<TViewModel>(result);
        }

        /// <inheritdoc />
        public async Task Delete(string id)
        {
            await fireStore.SoftDeleteDocument(id, CollectionName);
        }
    }
}