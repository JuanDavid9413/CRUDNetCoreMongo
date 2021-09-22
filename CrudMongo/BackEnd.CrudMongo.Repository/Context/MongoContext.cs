using BackEnd.CrudMongo.Entities.Conection;
using BackEnd.CrudMongo.Entities.DbSet;
using BackEnd.CrudMongo.Entities.Enums;
using BackEnd.CrudMongo.Utilities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Repository.Context
{
    public class MongoContext<T> : IMongoContextRespository<T>
    {
        private readonly IMongoCollection<T> _collection;
        private readonly DatabaseConfiguration _mongoSettings;
        private T _value = (T)Activator.CreateInstance(typeof(T));

        public MongoContext(IOptions<DatabaseConfiguration> mongoSettings)
        {
            _mongoSettings = mongoSettings.Value;
            MongoClient client = new MongoClient(_mongoSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_mongoSettings.DatabaseName);
            _collection = database.GetCollection<T>(_GetCollection());

        }

        /*Generic Methods*/
        public async Task<List<T>> GetAllAsync() => await _collection.Find(l => true).ToListAsync();

        public async Task<T> CreateAsync(T currentCollection)
        {
            await _collection.InsertOneAsync(currentCollection);
            return currentCollection;
        }

        public async Task<T> UpdateAsync(string id, T currentCollection)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            return await _collection.FindOneAndReplaceAsync(filter, currentCollection);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var filter = Builders<T>.Filter.Eq("id", id);
            var result = await _collection.DeleteOneAsync(filter);
            return true;

        }

        private string _GetCollection()
        {
            string result = null;
            Type type = _value.GetType();
            if (type == typeof(Users))
                result = _mongoSettings.UsersCollectionName;

            return result;
        }
    }
}
