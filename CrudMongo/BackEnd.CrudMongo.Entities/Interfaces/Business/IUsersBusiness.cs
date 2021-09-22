using BackEnd.CrudMongo.Entities.DbSet;
using BackEnd.CrudMongo.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Entities.Interfaces.Business
{
    public interface IUsersBusiness
    {
        Task<ResponseBase<Users>> CreateUsers(Users users);
        Task<ResponseBase<bool>> DeleteUsers(string id);
        Task<ResponseBase<List<Users>>> GetAllUsers();
        Task<ResponseBase<Users>> UpdateUsers(Users users);

    }
}
