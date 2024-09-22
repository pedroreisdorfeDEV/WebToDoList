using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Services.Repositories.Abstractions
{
    public interface IAtualizacaoTarefaRepository
    {
        public Task AtualizarTarefa(Tarefa tarefa);
    }
}
