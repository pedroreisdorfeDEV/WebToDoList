using Microsoft.Data.SqlClient;
using System.Data;
using WebToDoListKlassMatt.Data.dbCommands.Abstractions;
using WebToDoListKlassMatt.Data.dbQuerys.Abstractions;

namespace WebToDoListKlassMatt.Data.Contexts
{
    public class DataBaseContext
    {
        public IDbConnection connection;
        public ISQLQuerys sqlQuery;
        public ISQLCommands sqlCommand;
        public DataBaseContext(IDbConnection connection, ISQLQuerys siapQuery, ISQLCommands siapCommand)
        {
            this.connection = connection ?? throw new ArgumentNullException(nameof(DataBaseContext.connection));
            this.sqlQuery = siapQuery ?? throw new ArgumentNullException(nameof(sqlQuery));
            this.sqlCommand = siapCommand ?? throw new ArgumentNullException(nameof(sqlCommand));
        }

    }
}
