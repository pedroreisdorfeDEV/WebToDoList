using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace WebToDoListKlassMatt.Models.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Prazo { get; set; }
        public DateTime? DataEntrega { get; set; }
        public bool Concluida { get; set; }
        public int DiasParaPrazo { get; set; }
        public int DiasEmAtraso { get; set; }
        public bool AlertaDiaFinal { get; set; }
    }
}
