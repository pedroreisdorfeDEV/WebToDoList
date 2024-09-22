using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.Shared.Abstractions;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Services.Repositories.Abstractions;

namespace WebToDoListKlassMatt.UseCase.ExclusaoTarefa
{
    public class ExclusaoTarefaUseCase : IExclusaoTarefa
    {
        private readonly IOutputPort _outputPort;
        private readonly IExclusaoTarefaRepository _exclusaoTarefaRepository;

        public ExclusaoTarefaUseCase(IOutputPort outputPort, IExclusaoTarefaRepository exclusaoTarefaRepository)
        {
            _outputPort = outputPort;
            _exclusaoTarefaRepository = exclusaoTarefaRepository;
        }

        public async Task<IActionResult> ExecuteAsync(int idTarefa)
        {
            try
            {
                await _exclusaoTarefaRepository.ExcluirTarefa(idTarefa);
                return _outputPort.Success(idTarefa.ToString());
            }
            catch (Exception e)
            {

                return _outputPort.InvalidRequest(e.Message);
            }
        }
    }
}
