using System.Data;
using WebToDoListKlassMatt.Data.Connections.Abstractions;
using WebToDoListKlassMatt.Data.Contexts;
using WebToDoListKlassMatt.Data.dbCommands.Abstractions;
using WebToDoListKlassMatt.Data.dbCommands.Implementation;
using WebToDoListKlassMatt.Data.dbQuerys.Abstractions;
using WebToDoListKlassMatt.Data.dbQuerys.Implementation;
using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.Data.Connections
{
    public class DataBaseConnectionFactory : IDataBaseConnectionFactory
    {
        private readonly IConfiguration _configuration;
        //public DbConnectionFactory(IConfiguration configuration) => _configuration = configuration;
        public DataBaseConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DataBaseContext ObterContexto(string AppSettingsSection)
        {
            IConfigurationSection configuracaoSessao = _configuration.GetSection(AppSettingsSection);
            AppSettingsDbConfiguracao configSessao = new();
            ConnectionManager connectionManager = new();
            configuracaoSessao.Bind(configSessao);

            IDbConnection dbConnection;
            ISQLCommands sqlCommands;
            ISQLQuerys sqlQuerys;

            switch (configSessao.TipoBanco)
            {
                case EnumTipoBanco.SQLServer:
                    dbConnection = connectionManager.GetConnection();
                    sqlQuerys = new SQLQuerys();
                    sqlCommands = new SQLCommands();
                    break;
                default:
                    throw new NotImplementedException();
            }

            return new DataBaseContext(dbConnection, sqlQuerys, sqlCommands);
        }
    }
}
