using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Abstractions
{
    public interface IAtualizacaoTarefa
    {
        Task<IActionResult> ExecuteAsync(Tarefa tarefa);
    }
}
