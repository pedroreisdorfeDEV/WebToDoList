using Dapper;
using WebToDoListKlassMatt.Data.Connections.Abstractions;
using WebToDoListKlassMatt.Data.Contexts;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Services.Repositories.Abstractions;

namespace WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Services.Repositories
{
    public class ExclusaoTarefaRepository : IExclusaoTarefaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDataBaseConnectionFactory _dataBaseConnectionFactory;
        private readonly DataBaseContext _dbContext;

        public ExclusaoTarefaRepository(IConfiguration configuration, IDataBaseConnectionFactory dataBaseConnectionFactory)
        {
            _configuration = configuration;
            _dataBaseConnectionFactory = dataBaseConnectionFactory;
            _dbContext = _dataBaseConnectionFactory.ObterContexto(AppSettingsConstantes.DB_SQL);
        }

        public async Task ExcluirTarefa(int id)
        {
            try
            {
                await _dbContext.connection.ExecuteAsync(_dbContext.sqlCommand.RemoverTarefa(id));
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
