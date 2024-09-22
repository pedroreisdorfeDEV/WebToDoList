using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Services.Repositories.Abstractions
{
    public interface IObtencaoTarefasRepository
    {
        public Task<List<Tarefa>> BuscarTarefas();
    }
}
