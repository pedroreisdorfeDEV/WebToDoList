using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Models.Entities;

namespace WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Abstractions
{
    public interface IObtencaoTarefas
    {
        Task<IActionResult> ExecuteAsync();
    }
}
