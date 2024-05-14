using CRUD_db.Interfaces;
using CRUD_db.Models;
using Dapper;

namespace CRUD_db.Services
{
    public class SupplierService : ISupplierService
    {
        private IConnectionService _connectionService;
        public SupplierService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task AddSupplier(Supplier newSupplier)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"INSERT INTO Suppliers (Name," +
            $"Contact," +
            $"Email," +
            $"Address," +
            $"VALUES (@Name, @Contact, @Email, @Address)";

            await connection.QueryAsync<Supplier>(query, newSupplier);
        }

        public async Task DeleteSupplier(int supplierId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query =  $"DELETE FROM Suppliers WHERE SupplierId = {supplierId}";
            await connection.QueryAsync<Supplier>(query);
        }

        public async Task<Supplier> GetById(int supplierId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"SELECT * FROM Suppliers WHERE SupplierId = {supplierId}";
            return await connection.QueryFirstAsync<Supplier>(query);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = "SELECT * FROM Suppliers";
            return await connection.QueryAsync<Supplier>(query);
        }

        public async Task UpdateSupplier(Supplier updatedSupplier)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var supplierBefore = await GetById(updatedSupplier.SupplierId);
            supplierBefore.Name = updatedSupplier.Name ?? supplierBefore.Name;
            supplierBefore.Contact = updatedSupplier.Contact ?? supplierBefore.Contact;
            supplierBefore.Email = updatedSupplier.Email ?? supplierBefore.Email;
            supplierBefore.Address = updatedSupplier.Address ?? supplierBefore.Address;

            var query = $"UPDATE Suppliers SET FullName = @FullName, " +
                $"Contact = @Contact, " +
                $"Email = @Email, " +
                $"Address = @Address, " +
                $"WHERE SupplierId = @SupplierId";
            await connection.QueryAsync<Supplier>(query, updatedSupplier);
        }
    }
}
