using Dapper;
using WebToDoListKlassMatt.Data.Connections.Abstractions;
using WebToDoListKlassMatt.Data.Contexts;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Services.Repositories.Abstractions;

namespace WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Services.Repositories
{
    public class AtualizacaoTarefaRepository : IAtualizacaoTarefaRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDataBaseConnectionFactory _dataBaseConnectionFactory;
        private readonly DataBaseContext _dbContext;

        public AtualizacaoTarefaRepository(IConfiguration configuration, IDataBaseConnectionFactory dataBaseConnectionFactory)
        {
            _configuration = configuration;
            _dataBaseConnectionFactory = dataBaseConnectionFactory;
            _dbContext = _dataBaseConnectionFactory.ObterContexto(AppSettingsConstantes.DB_SQL);
        }
        public async Task AtualizarTarefa(Tarefa tarefa)
        {
            try
            {
                await _dbContext.connection.ExecuteAsync(_dbContext.sqlCommand.AtualizarTarefa(tarefa));
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}

