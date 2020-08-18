using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Services.FireStore
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

        /// <summary>
        /// Deletes the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns></returns>
        Task DeleteDocument(string id, string collectionName);

        /// <summary>
        /// Soft deletes the document.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="collectionName">Name of the collection.</param>
        /// <returns></returns>
        Task SoftDeleteDocument(string id, string collectionName);
    }
}