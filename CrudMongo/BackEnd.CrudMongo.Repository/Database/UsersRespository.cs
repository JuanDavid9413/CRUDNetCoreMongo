using BackEnd.CrudMongo.Entities.Conection;
using BackEnd.CrudMongo.Entities.DbSet;
using BackEnd.CrudMongo.Entities.Enums;
using BackEnd.CrudMongo.Entities.Interfaces.Repository;
using BackEnd.CrudMongo.Entities.Models;
using BackEnd.CrudMongo.Utilities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Repository.Context
{
    public class UsersRepository: IUsersRepository
    {
        private readonly IMongoCollection<Users> _collection;
        private readonly DatabaseConfiguration _mongoSettings;

        public UsersRepository(IOptions<DatabaseConfiguration> mongoSettings)
        {
            _mongoSettings = mongoSettings.Value;
            MongoClient client = new MongoClient(_mongoSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(_mongoSettings.DatabaseName);
            _collection = database.GetCollection<Users>(_mongoSettings.UsersCollectionName);

        }

        /*Generic Methods*/
        public async Task<List<Users>> GetAllAsync() => await _collection.Find(l => true).ToListAsync();

        public async Task<Users> CreateAsync(Users currentCollection)
        {
            await _collection.InsertOneAsync(currentCollection);
            return currentCollection;
        }

        public async Task<Users> UpdateAsync(string id, Users currentCollection)
        {            
            var result = await _collection.FindOneAndReplaceAsync(l => l.Id == id, currentCollection);
            return currentCollection;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(l => l.Id == id);
            return true;

        }

        //private string _GetCollection()
        //{
        //    string result = null;
        //    Type type = _value.GetType();
        //    if (type == typeof(Users))
        //        result = _mongoSettings.UsersCollectionName;

        //    return result;
        //}
    }
}
