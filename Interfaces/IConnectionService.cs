using System.Data.SqlClient;

namespace CRUD_db.Interfaces
{
    public interface IConnectionService
    {
        SqlConnection GetConnection();
    }
}
