using WebToDoListKlassMatt.Data.dbQuerys.Abstractions;

namespace WebToDoListKlassMatt.Data.dbQuerys.Implementation
{
    public partial class SQLQuerys : ISQLQuerys
    {
        public string ObterTarefas()
        {
            string query = "Select * from Tarefas";
            return query;   
        }
    }
}
