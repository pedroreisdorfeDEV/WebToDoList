using WebToDoListKlassMatt.Data.dbCommands.Abstractions;
using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.Data.dbCommands.Implementation
{
    public partial class SQLCommands : ISQLCommands
    {
        public string InserirTarefa(Tarefa tarefa)
        {
            string query = $" INSERT INTO Tarefas (Nome, Descricao, Prazo, concluida)" +
                $"VALUES('{tarefa.Nome}', '{tarefa.Descricao}', '{tarefa.Prazo.ToString()}', {(tarefa.Concluida ? 1 : 0)})";

            return query;
        }
        public string AtualizarTarefa(Tarefa tarefa)
        {
            tarefa.DataEntrega = tarefa.Concluida ? DateTime.Now : null;
            string query = $"UPDATE Tarefas SET Nome = '{tarefa.Nome}', Descricao = '{tarefa.Descricao}', prazo = '{tarefa.Prazo.ToString()}', concluida = {(tarefa.Concluida ? 1 : 0)}, dataEntrega = '{tarefa.DataEntrega.ToString()}'" +
                $"where id = {tarefa.Id}";
            return query;
        }
        public string RemoverTarefa(int idTarefa)
        {
            string query = $"Delete from Tarefas where Id = {idTarefa}";

            return query;
        }
    }
}
