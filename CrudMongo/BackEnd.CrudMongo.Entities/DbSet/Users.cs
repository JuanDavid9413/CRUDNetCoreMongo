using BackEnd.CrudMongo.Entities.Conection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Entities.DbSet
{
    public class Users : IIdentity<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
    }
}
