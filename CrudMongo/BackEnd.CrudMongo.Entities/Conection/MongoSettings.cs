using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Entities.DbSet
{
    public class MongoSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        //Collections Mongo
        public string UsersCollectionName { get; set; }
    }
}
