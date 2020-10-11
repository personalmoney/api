using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Services.FireStore
{
    /// <summary>
    /// FireStore interface to handle the fire store database communication
    /// </summary>
    public interface IFireStoreService
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetCollection<T>(string collection) where T : BaseModel;

        /// <summary>
        /// Gets the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="modifiedTime">The modified time.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetCollection<T>(string collection, DateTime? modifiedTime) where T : BaseModel;

        /// <summary>
        /// Searches the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="conditions">The conditions.</param>
        /// <returns></returns>
        Task<IEnumerable<T>> SearchCollection<T>(string collection, IDictionary<string, dynamic> conditions) where T : BaseModel;

        /// <summary>
        /// Gets the document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetDocument<T>(string collection, string id) where T : UserModel;

        /// <summary>
        /// Finds the document by name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Task<T> FindDocumentByName<T>(string collection, string name) where T : UserModel;

        /// <summary>
        /// Finds the document by name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="name">The name.</param>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> FindDocumentByName<T>(string collection, string name, string id) where T : UserModel;

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