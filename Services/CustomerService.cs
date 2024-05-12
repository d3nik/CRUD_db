using CRUD_db.Interfaces;
using CRUD_db.Models;
using Dapper;

namespace CRUD_db.Services
{
    public class CustomerService : ICustomerService
    {
        private IConnectionService _connectionService;
        public CustomerService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task AddCustomer(Customer newCustomer)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"INSERT INTO Customers (FullName," +
            $"Phone," +
            $"Email," +
            $"City," +
            $"ZipCode) " +
            $"VALUES (@FullName, @Phone, @Email, @City, @ZipCode)";

            await connection.QueryAsync<Customer>(query, newCustomer);
        }

        public async Task DeleteCustomer(int customerId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query =  $"DELETE FROM Customers WHERE CustomerId = {customerId}";
            await connection.QueryAsync<Customer>(query);
        }

        public async Task<Customer> GetById(int customerId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"SELECT * FROM Customers WHERE CustomerId = {customerId}";
            return await connection.QueryFirstAsync<Customer>(query);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = "SELECT * FROM Customers";
            return await connection.QueryAsync<Customer>(query);
        }

        public async Task UpdateCustomer(Customer updatedCustomer)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var customerBefore = await GetById(updatedCustomer.CustomerId);
            customerBefore.FullName = updatedCustomer.FullName ?? customerBefore.FullName;
            customerBefore.Phone = updatedCustomer.Phone ?? customerBefore.Phone;
            customerBefore.Email = updatedCustomer.Email ?? customerBefore.Email;
            customerBefore.City = updatedCustomer.City ?? customerBefore.City;
            customerBefore.ZipCode = updatedCustomer.ZipCode ?? customerBefore.ZipCode;

            var query = $"UPDATE Customers SET FullName = @FullName, " +
                $"Phone = @Phone, " +
                $"Email = @Email, " +
                $"City = @City, " +
                $"ZipCode = @ZipCode " +
                $"WHERE CustomerId = @CustomerId";
            await connection.QueryAsync<Customer>(query, updatedCustomer);
        }
    }
}
