using BackEnd.CrudMongo.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Entities.Interfaces.Repository
{
    public interface IUsersRepository
    {
        Task<List<Users>> GetAllAsync();
        Task<Users> CreateAsync(Users currentCollection);
        Task<Users> UpdateAsync(string id, Users currentCollection);
        Task<bool> DeleteAsync(string id);
    }
}
