using CRUD_db.Interfaces;
using CRUD_db.Models;
using Dapper;

namespace CRUD_db.Services
{
    public class StoreService : IStoreService
    {
        private IConnectionService _connectionService;
        public StoreService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task AddStore(Store newStore)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"INSERT INTO Stores (Phone," +
            $"Email," +
            $"Street," +
            $"City," +
            $"ZipCode) " +
            $"VALUES (@Phone, @Email, @Street, @City, @ZipCode)";

            await connection.QueryAsync<Store>(query, newStore);
        }

        public async Task DeleteStore(int storeId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query =  $"DELETE FROM Stores WHERE StoreId = {storeId}";
            await connection.QueryAsync<Store>(query);
        }

        public async Task<Store> GetById(int storeId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"SELECT * FROM Stores WHERE StoreId = {storeId}";
            return await connection.QueryFirstAsync<Store>(query);
        }

        public async Task<IEnumerable<Store>> GetStores()
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = "SELECT * FROM Stores";
            return await connection.QueryAsync<Store>(query);
        }

        public async Task UpdateStore(Store updatedStore)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var storeBefore = await GetById(updatedStore.StoreId);
            storeBefore.Phone = updatedStore.Phone ?? storeBefore.Phone;
            storeBefore.Email = updatedStore.Email ?? storeBefore.Email;
            storeBefore.Street = updatedStore.Street ?? storeBefore.Street;
            storeBefore.City = updatedStore.City ?? storeBefore.City;
            storeBefore.ZipCode = updatedStore.ZipCode ?? storeBefore.ZipCode;

            var query = $"UPDATE Stores SET Phone = @Phone, " +
                $"Email = @Email, " +
                $"Street = @Street, " +
                $"City = @City, " +
                $"ZipCode = @ZipCode " +
                $"WHERE StoreId = @StoreId";
            await connection.QueryAsync<Store>(query, updatedStore);
        }
    }
}
