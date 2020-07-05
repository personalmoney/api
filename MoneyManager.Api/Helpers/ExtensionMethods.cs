using System;
using System.Collections.Generic;
using System.ComponentModel;
using Google.Cloud.Firestore;
using MoneyManager.Api.Models.Base;
using Newtonsoft.Json;

namespace MoneyManager.Api.Helpers
{
    /// <summary>
    /// Extension methods
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// Converts to dictionary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">The object.</param>
        /// <returns></returns>
        internal static IDictionary<string, dynamic> ToDictionary<T>(this T obj) where T : BaseModel
        {
            var json = JsonConvert.SerializeObject(obj, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            var dictionary = ToDictionary<dynamic>(obj);
            return dictionary;
        }

        internal static IDictionary<string, T> ToDictionary<T>(this object source)
        {
            if (source == null)
                ThrowExceptionWhenSourceArgumentIsNull();

            var dictionary = new Dictionary<string, T>();
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
                AddPropertyToDictionary<T>(property, source, dictionary);
            return dictionary;
        }

        private static void AddPropertyToDictionary<T>(PropertyDescriptor property, object source, IDictionary<string, T> dictionary)
        {
            object value = property.GetValue(source);
            FirestorePropertyAttribute firStoreAttribute = property.Attributes[typeof(FirestorePropertyAttribute)] as FirestorePropertyAttribute;
            if (firStoreAttribute == null)
            {
                return;
            }
            if (IsOfType<T>(value))
                dictionary.Add(firStoreAttribute.Name, (T)value);
        }

        private static bool IsOfType<T>(object value)
        {
            return value is T;
        }

        private static void ThrowExceptionWhenSourceArgumentIsNull()
        {
            throw new ArgumentNullException("source", "Unable to convert object to a dictionary. The source object is null.");
        }
    }
}