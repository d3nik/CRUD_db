using CRUD_db.Interfaces;
using System.Data.SqlClient;

namespace CRUD_db.Services
{
    public class ConnectionService : IConnectionService
    {
        private readonly string _connectionString;

        public ConnectionService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ComputerComponentsStore")!;
        }

        public SqlConnection GetConnection() => new(_connectionString);
    
    }
}
