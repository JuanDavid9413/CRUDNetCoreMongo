using MongoDB.Bson;

namespace BackEnd.CrudMongo.Entities.Conection
{
    public class IIdentity<TId>
    {
        TId Id { get; set; }
    }
}
