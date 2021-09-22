using BackEnd.CrudMongo.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Utilities
{
    public static class GenericUtility
    {
        public static void ResponseBaseCatch<T>(this ResponseBase<T> data, bool validation, HttpStatusCode code, string message)
        {
            ResponseBase<T> result = data;
            if (validation) 
            {
                result.Code = (int)code;
                result.Message = message;
            }
        }
    }
}
