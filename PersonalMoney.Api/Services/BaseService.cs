﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PersonalMoney.Api.Models;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Services
{
    /// <summary>
    /// Base service
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    /// <seealso cref="IBaseService{TModel, TViewModel}" />
    public abstract class BaseService<TModel, TViewModel> : IBaseService<TModel, TViewModel> where TModel : TimeModel
    {
        private readonly IMapper mapper;
        private readonly AppDbContext dataContext;
        private readonly UserResolverService userResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TModel, TViewModel}"/> class.
        /// </summary>
        /// <param name="mapper">The mapper.</param>
        /// <param name="dataContext">The database context</param>
        /// <param name="userResolver">The user resolver service</param>
        protected BaseService(IMapper mapper, AppDbContext dataContext, UserResolverService userResolver)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
            this.userResolver = userResolver;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TViewModel>> Get()
        {
            var dbSet = dataContext.Set<TModel>();
            return await GetData(dbSet);
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <param name="dbSet">The database set.</param>
        /// <returns></returns>
        protected async Task<IEnumerable<TViewModel>> GetData(IQueryable<TModel> dbSet)
        {
            var models = await dbSet
                .Where(c => !c.IsDeleted)
                .Where(c => c.UserId == userResolver.GetUserId())
                .ToListAsync();
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(models);
            return viewModels;
        }

        /// <inheritdoc />
        public virtual async Task<IEnumerable<TViewModel>> Get(DateTime? lastSyncTime)
        {
            var models = await dataContext.Set<TModel>()
                .Where(c => c.UpdatedTime > lastSyncTime)
                .Where(c => c.UserId == userResolver.GetUserId())
                .ToListAsync();
            var viewModels = mapper.Map<IEnumerable<TViewModel>>(models);
            return viewModels;
        }

        /// <inheritdoc />
        public virtual async Task<TViewModel> Get(int id)
        {
            var view = await dataContext.Set<TModel>()
                .Where(c => !c.IsDeleted)
                .Where(c => c.Id == id)
                .Where(c => c.UserId == userResolver.GetUserId())
                .FirstOrDefaultAsync();
            var viewModel = mapper.Map<TViewModel>(view);
            return viewModel;
        }

        /// <inheritdoc />
        public virtual async Task<TViewModel> Create(TViewModel model)
        {
            var document = mapper.Map<TModel>(model);
            EntityEntry<TModel> result = await dataContext.Set<TModel>().AddAsync(document);
            await dataContext.SaveChangesAsync();
            return mapper.Map<TViewModel>(result.Entity);
        }

        /// <inheritdoc />
        public virtual async Task<TViewModel> Update(int id, TViewModel model)
        {
            var document = mapper.Map<TModel>(model);
            EntityEntry<TModel> result = dataContext.Set<TModel>().Update(document);
            await dataContext.SaveChangesAsync();
            return mapper.Map<TViewModel>(result.Entity);
        }

        /// <inheritdoc />
        public virtual async Task Delete(int id)
        {
            TModel result = await dataContext.Set<TModel>().FindAsync(id);
            result.IsDeleted = true;
            await dataContext.SaveChangesAsync();
        }
    }
}