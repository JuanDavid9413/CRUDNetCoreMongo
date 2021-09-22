using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.CrudMongo.Repository.Context
{
    public interface IMongoContextRespository<T>
    {
        Task<T> CreateAsync(T currentCollection);
        Task<bool> DeleteAsync(string id);
        Task<List<T>> GetAllAsync();
        Task<T> UpdateAsync(string id, T currentCollection);
    }
}