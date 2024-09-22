using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.Data.dbCommands.Abstractions
{
    public partial interface ISQLCommands
    {
        public string InserirTarefa(Tarefa tarefa);
        public string RemoverTarefa(int idTarefa);
        public string AtualizarTarefa(Tarefa tarefa);
    }
}
