﻿using BackEnd.CrudMongo.Entities.DbSet;
using BackEnd.CrudMongo.Repository.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Repository
{
    public static class StatupRepository
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IMongoContextRespository<>), typeof(MongoContext<>));
            //services.Configure<DatabaseConfiguration>( configuration => configuration.GetSection("DatabaseConfiguration"));
            //configuration.GetSection("DatabaseConfiguration:ConnectionString")
            //    configuration.GetSection("DatabaseConfiguration:UsersCollectionName")


        }
    }
}
