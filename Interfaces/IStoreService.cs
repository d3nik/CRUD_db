using CRUD_db.Models;

namespace CRUD_db.Interfaces
{
    public interface IStoreService
    {
        Task<IEnumerable<Store>> GetStores();
        Task<Store> GetById(int storeId);
        Task AddStore(Store newStore);
        Task UpdateStore(Store newStore);
        Task DeleteStore(int storeId);
    }
}
