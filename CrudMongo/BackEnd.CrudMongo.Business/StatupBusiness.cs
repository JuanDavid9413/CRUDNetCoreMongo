using BackEnd.CrudMongo.Entities.Interfaces.Business;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Business
{
    public static class StatupBusiness
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddTransient<IUsersBusiness, UsersBusiness>();
        }
    }
}
