using CRUD_db.Interfaces;
using CRUD_db.Models;
using Dapper;

namespace CRUD_db.Services
{
    public class StaffService : IStaffService
    {
        private IConnectionService _connectionService;
        public StaffService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task AddStaff(Staff newStaff)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"INSERT INTO Staff (FirstName," +
            $"LastName," +
            $"Email," +
            $"Phone," +
            $"HireDate," +
            $"StoreId) " +
            $"VALUES (@FirstName, @LastName, @Email, @Phone, @HireDate, @StoreId)";

            await connection.QueryAsync<Staff>(query, newStaff);
        }

        public async Task DeleteStaff(int staffId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query =  $"DELETE FROM Staff WHERE StaffId = {staffId}";
            await connection.QueryAsync<Staff>(query);
        }

        public async Task<Staff> GetById(int staffId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"SELECT * FROM Staff WHERE StaffId = {staffId}";
            return await connection.QueryFirstAsync<Staff>(query);
        }

        public async Task<IEnumerable<Staff>> GetStaff()
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = "SELECT * FROM Staff";
            return await connection.QueryAsync<Staff>(query);
        }

        public async Task UpdateStaff(Staff updatedStaff)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var staffBefore = await GetById(updatedStaff.StaffId);
            staffBefore.FirstName = updatedStaff.FirstName ?? staffBefore.FirstName;
            staffBefore.LastName = updatedStaff.LastName ?? staffBefore.LastName;
            staffBefore.Email = updatedStaff.Email ?? staffBefore.Email;
            staffBefore.Phone = updatedStaff.Phone ?? staffBefore.Phone;
            staffBefore.HireDate = updatedStaff.HireDate ?? staffBefore.HireDate;
            staffBefore.StoreId = updatedStaff.StoreId ?? staffBefore.StoreId;

            var query = $"UPDATE Staff SET FirstName = @FirstName, " +
                $"LastName = @LastName, " +
                $"Email = @Email, " +
                $"Phone = @Phone, " +
                $"HireDate = @HireDate, " +
                $"StoreId = @StoreId " +
                $"WHERE StaffId = @StaffId";
            await connection.QueryAsync<Staff>(query, updatedStaff);
        }
    }
}
