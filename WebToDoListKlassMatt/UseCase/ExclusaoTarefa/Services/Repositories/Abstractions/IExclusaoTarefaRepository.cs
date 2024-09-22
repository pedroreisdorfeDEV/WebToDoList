namespace WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Services.Repositories.Abstractions
{
    public interface IExclusaoTarefaRepository
    {
        public Task ExcluirTarefa(int id);
    }
}
