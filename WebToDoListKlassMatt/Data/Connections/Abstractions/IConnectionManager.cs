using Microsoft.Data.SqlClient;

namespace WebToDoListKlassMatt.Data.Connections.Abstractions
{
    public interface IConnectionManager
    {
        SqlConnection GetConnection();
    }
}
