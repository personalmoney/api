using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Cloud.Firestore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MoneyManager.Api.Helpers;
using MoneyManager.Api.Models.Base;

namespace MoneyManager.Api.Services.FireStore
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
            var query = collectionRef.WhereEqualTo("userId", userId);
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
            return string.Equals(result.UserId, userId) ? result : default;
        }

        /// <inheritdoc />
        public async Task<T> AddDocument<T>(T document, string collectionName) where T : TimeModel
        {
            document.UpdateTime = DateTime.UtcNow;
            document.CreateTime = DateTime.UtcNow;
            document.UserId = userId;
            DocumentReference addedDocRef = await db.Collection(collectionName).AddAsync(document);
            document.Id = addedDocRef.Id;
            return document;
        }

        /// <inheritdoc />
        public async Task<T> UpdateDocument<T>(T document, string collectionName) where T : TimeModel
        {
            DocumentReference docRef = db.Collection(collectionName).Document(document.Id);
            var snapshot = await docRef.GetSnapshotAsync();
            if (!snapshot.Exists)
            {
                return default;
            }

            if (!string.Equals(snapshot.GetValue<string>("userId"), userId))
            {
                return default;
            }
            document.UpdateTime = DateTime.UtcNow;
            document.UserId = userId;
            await docRef.SetAsync(document, SetOptions.MergeAll);
            return document;
        }
    }
}