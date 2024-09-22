using Microsoft.Data.SqlClient;
using WebToDoListKlassMatt.Data.Connections.Abstractions;

namespace WebToDoListKlassMatt.Data.Connections
{
    public class ConnectionManager : IConnectionManager
    {
        private static string stringDeConexao = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_projetoKlassMatt;Data Source=LAPTOP-8RL84DG9\MSSQLSERVER01;Encrypt=False;";

        public static SqlConnection connection = null;

        public ConnectionManager()
        {
            connection = new SqlConnection(stringDeConexao);
        }
        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
