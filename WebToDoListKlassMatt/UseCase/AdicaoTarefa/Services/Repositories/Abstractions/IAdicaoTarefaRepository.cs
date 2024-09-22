using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.UseCase.AdicaoTarefa.Services.Repositories.Abstractions
{
    public interface IAdicaoTarefaRepository
    {
        public Task AdicionarTarefa(Tarefa tarefa);
    }
}
