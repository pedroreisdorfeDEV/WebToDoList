using Microsoft.EntityFrameworkCore;
using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.Data.Contexts
{
    public class Contexto : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=DB_projetoKlassMatt;Data Source=LAPTOP-8RL84DG9\MSSQLSERVER01;Encrypt=False;";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
