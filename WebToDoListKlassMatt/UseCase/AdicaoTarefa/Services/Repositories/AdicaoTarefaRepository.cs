using WebToDoListKlassMatt.Data.Connections.Abstractions;
using WebToDoListKlassMatt.Data.Contexts;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa.Services.Repositories.Abstractions;
using Dapper;

namespace WebToDoListKlassMatt.UseCase.AdicaoTarefa.Services.Repositories
{
    public class AdicaoTarefaRepository : IAdicaoTarefaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDataBaseConnectionFactory _dataBaseConnectionFactory;
        private readonly DataBaseContext _dbContext;

        public AdicaoTarefaRepository(IConfiguration configuration, IDataBaseConnectionFactory dataBaseConnectionFactory)
        {
            _configuration = configuration;
            _dataBaseConnectionFactory = dataBaseConnectionFactory;
            _dbContext = _dataBaseConnectionFactory.ObterContexto(AppSettingsConstantes.DB_SQL);
        }

        public async Task AdicionarTarefa(Tarefa tarefa)
        {
            try
            {
                await _dbContext.connection.ExecuteAsync(_dbContext.sqlCommand.InserirTarefa(tarefa));
            }
            catch (Exception e)
            {

                throw;
            }
    
        }
    }
}
