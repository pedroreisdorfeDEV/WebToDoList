using Microsoft.AspNetCore.Mvc;

namespace WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Abstractions
{
    public interface IExclusaoTarefa
    {
        Task<IActionResult> ExecuteAsync(int idTarefa);
    }
}
