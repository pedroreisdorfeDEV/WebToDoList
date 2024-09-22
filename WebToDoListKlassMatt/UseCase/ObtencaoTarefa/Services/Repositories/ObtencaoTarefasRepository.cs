using Dapper;
using WebToDoListKlassMatt.Data.Connections.Abstractions;
using WebToDoListKlassMatt.Data.Contexts;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Services.Repositories.Abstractions;

namespace WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Services.Repositories
{
    public class ObtencaoTarefasRepository : IObtencaoTarefasRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IDataBaseConnectionFactory _dataBaseConnectionFactory;
        private readonly DataBaseContext _dbContext;

        public ObtencaoTarefasRepository(IConfiguration configuration, IDataBaseConnectionFactory dataBaseConnectionFactory)
        {
            _configuration = configuration;
            _dataBaseConnectionFactory = dataBaseConnectionFactory;
            _dbContext = _dataBaseConnectionFactory.ObterContexto(AppSettingsConstantes.DB_SQL);
        }

        public async Task<List<Tarefa>> BuscarTarefas()
        {
            try
            {
             
                List<Tarefa> listaTarefas = [];
                IEnumerable<Tarefa> listaTarefasEnumerable = await _dbContext.connection.QueryAsync<Tarefa>(_dbContext.sqlQuery.ObterTarefas());
                if(listaTarefasEnumerable != null && listaTarefasEnumerable.Count() > 0)
                {
                    foreach (var tarefa in listaTarefasEnumerable) {
                        TimeSpan diferenca = tarefa.Prazo.Date - DateTime.Now.Date;
                        tarefa.DiasParaPrazo = diferenca.Days;
                        if (tarefa.DiasParaPrazo < 0)
                        {
                            tarefa.DiasEmAtraso = diferenca.Days * -1;
                        }
                        if(tarefa.DiasParaPrazo == 0)
                        {
                            tarefa.AlertaDiaFinal = true;
                        }
                       
                        listaTarefas.Add(tarefa);   
                    }
                }
                return listaTarefas;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
