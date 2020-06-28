using System.Collections.Generic;
using System.Threading.Tasks;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Services.FireStore
{
    /// <summary>
    /// FireStore interface to handle the fire store database communication
    /// </summary>
    internal interface IFireStoreService
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetCollection<T>(string collection) where T : BaseModel;

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetDocument<T>(string collection, string id) where T : UserModel;

        /// <summary>
        /// Adds the document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document">The document.</param>
        /// <param name="collectionName">The collection name.</param>
        /// <returns></returns>
        Task<T> AddDocument<T>(T document, string collectionName) where T : TimeModel;

        /// <summary>
        /// Updates the document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document">The document.</param>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns></returns>
        Task<T> UpdateDocument<T>(T document, string collectionName) where T : TimeModel;
    }
}