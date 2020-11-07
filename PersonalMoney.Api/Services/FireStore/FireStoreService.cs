using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PersonalMoney.Api.Helpers;
using PersonalMoney.Api.Models.Base;

namespace PersonalMoney.Api.Services.FireStore
{
    internal class FireStoreService : IFireStoreService
    {
        private readonly string userId;
        private readonly FirestoreDb db;

        public FireStoreService(IConfiguration configuration, IHttpContextAccessor httpAccess)
        {
            userId = httpAccess.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "user_id")!.Value;
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("Invalid user");
            }
            db = FirestoreDb.Create(configuration["FireBaseId"]);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetCollection<T>(string collection) where T : BaseModel
        {
            CollectionReference collectionRef = db.Collection(collection);
            var query = collectionRef.WhereEqualTo("userId", userId)
                .WhereEqualTo("isDeleted", false);
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            return snapshot.Documents.Select(c => c.ConvertToWithId<T>());
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> GetCollection<T>(string collection, DateTime? modifiedTime) where T : BaseModel
        {
            CollectionReference collectionRef = db.Collection(collection);
            var query = collectionRef.WhereEqualTo("userId", userId);
            if (modifiedTime.HasValue)
            {
                query = query.WhereGreaterThanOrEqualTo("updateTime", modifiedTime.Value.ToUniversalTime());
            }
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            return snapshot.Documents.Select(c => c.ConvertToWithId<T>());
        }

        /// <inheritdoc />
        public async Task<IEnumerable<T>> SearchCollection<T>(string collection, IDictionary<string, dynamic> conditions) where T : BaseModel
        {
            CollectionReference collectionRef = db.Collection(collection);
            var query = collectionRef.WhereEqualTo("userId", userId)
                .WhereEqualTo("isDeleted", false);
            foreach ((string key, dynamic value) in conditions)
            {
                query = query.WhereEqualTo(key, value);
            }
            QuerySnapshot snapshot = await query.GetSnapshotAsync();
            return snapshot.Documents.Select(c => c.ConvertToWithId<T>());
        }

        /// <inheritdoc />
        public async Task<T> GetDocument<T>(string collection, string id) where T : UserModel
        {
            var docRef = db.Collection(collection).Document(id);

            var snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists)
            {
                return default;
            }

            T result = snapshot.ConvertToWithId<T>();
            if (result.IsDeleted)
            {
                return default;
            }
            return string.Equals(result.UserId, userId) ? result : default;
        }

        /// <inheritdoc />
        public async Task<T> AddDocument<T>(T document, string collectionName) where T : TimeModel
        {
            document.UpdatedTime = DateTime.UtcNow;
            document.CreatedTime = DateTime.UtcNow;
            document.UserId = userId;
            DocumentReference addedDocRef = await db.Collection(collectionName).AddAsync(document);
            document.Id = addedDocRef.Id;
            return document;
        }

        /// <inheritdoc />
        public async Task<T> UpdateDocument<T>(T document, string collectionName) where T : TimeModel
        {
            var docRef = await CheckDocumentUser(document.Id, collectionName);
            if (docRef == null)
            {
                return default;
            }
            document.UpdatedTime = DateTime.UtcNow;
            document.UserId = userId;
            await docRef.SetAsync(document.ToDictionary(), SetOptions.MergeAll);
            return document;
        }

        /// <inheritdoc />
        public async Task DeleteDocument(string id, string collectionName)
        {
            var docRef = await CheckDocumentUser(id, collectionName);
            if (docRef == null)
            {
                return;
            }
            await docRef.DeleteAsync();
        }

        /// <inheritdoc />
        public async Task SoftDeleteDocument(string id, string collectionName)
        {
            var docRef = await CheckDocumentUser(id, collectionName);
            if (docRef == null)
            {
                return;
            }

            var dictionary = new Dictionary<string, dynamic>
            {
                ["updateTime"] = DateTime.UtcNow,
                ["isDeleted"] = true
            };
            await docRef.SetAsync(dictionary, SetOptions.MergeAll);
        }

        /// <inheritdoc />
        public async Task UpdateTime(string id, string collectionName)
        {
            var docRef = await CheckDocumentUser(id, collectionName);
            if (docRef == null)
            {
                return;
            }

            var dictionary = new Dictionary<string, dynamic>
            {
                ["updateTime"] = DateTime.UtcNow
            };
            await docRef.SetAsync(dictionary, SetOptions.MergeAll);
        }

        private async Task<DocumentReference> CheckDocumentUser(string id, string collectionName)
        {
            var docRef = db.Collection(collectionName).Document(id);
            var snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists)
            {
                return null;
            }

            return !string.Equals(snapshot.GetValue<string>("userId"), userId) ? null : docRef;
        }

        /// <inheritdoc />
        public async Task<T> FindDocumentByName<T>(string collection, string name) where T : UserModel
        {
            var collectionReference = db.Collection(collection);
            Query query = collectionReference.WhereEqualTo("userId", userId)
                .WhereEqualTo("isDeleted", false)
                .WhereEqualTo("name_lowercase", name!.ToLower());

            var snapshot = await query.GetSnapshotAsync();
            return snapshot.FirstOrDefault()?.ConvertToWithId<T>();
        }

        /// <inheritdoc />
        public async Task<T> FindDocumentByName<T>(string collection, string name, string id) where T : UserModel
        {
            var collectionReference = db.Collection(collection);
            Query query = collectionReference.WhereEqualTo("userId", userId)
                .WhereEqualTo("isDeleted", false)
                .WhereEqualTo("name_lowercase", name!.ToLower());

            var snapshot = await query.GetSnapshotAsync();
            return snapshot.FirstOrDefault(c => c.Id != id)?.ConvertToWithId<T>();
        }
    }
}