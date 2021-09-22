using BackEnd.CrudMongo.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Utilities
{
    public static class ConvertTypes
    {
        /// <summary>
        /// Return Name Collection
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetEnumString(this MongoCollections value)
        {
            string collectionName = null;
            switch (value)
            {
                case MongoCollections.Users:
                    collectionName = "Users";
                    break;
            }

            return collectionName;
        }
    }
}
