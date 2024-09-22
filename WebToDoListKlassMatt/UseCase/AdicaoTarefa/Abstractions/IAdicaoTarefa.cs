using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.UseCase.AdicaoTarefa.Abstractions
{
    public interface IAdicaoTarefa
    {
        Task<IActionResult> ExecuteAsync(Tarefa tarefa);
    }
}
