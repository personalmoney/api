﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Services
{
    /// <summary>
    /// Collection base services
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    /// <typeparam name="TViewModel">The type of the view model.</typeparam>
    public interface IBaseService<TModel, TViewModel> where TModel : TimeModel
    {

        /// <summary>
        /// Gets records for the given collection.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TViewModel>> Get();

        /// <summary>
        /// Gets the specified last synchronize time.
        /// </summary>
        /// <param name="lastSyncTime">The last synchronize time.</param>
        /// <returns></returns>
        Task<IEnumerable<TViewModel>> Get(DateTime? lastSyncTime);

        /// <summary>
        /// Gets the record with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<TViewModel> Get(int id);

        /// <summary>
        /// Creates the record with the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<TViewModel> Create(TViewModel model);

        /// <summary>
        /// Updates the record with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        Task<TViewModel> Update(int id, TViewModel model);

        /// <summary>
        /// Deletes the record with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task Delete(int id);
    }
}