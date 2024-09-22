using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.Shared.Abstractions;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa.Services.Repositories.Abstractions;

namespace WebToDoListKlassMatt.UseCase.AdicaoTarefa
{
    public class AdicaoTarefaUseCase : IAdicaoTarefa
    {
        private readonly IOutputPort _outputPort;

        private readonly IAdicaoTarefaRepository _adicaoTarefaRepository;

        public AdicaoTarefaUseCase(IOutputPort outputPort, IAdicaoTarefaRepository adicaoTarefaRepository)
        {
            _outputPort = outputPort;
            _adicaoTarefaRepository = adicaoTarefaRepository;
        }

        public async Task<IActionResult> ExecuteAsync(Tarefa tarefa)
        {
            try
            {
                await _adicaoTarefaRepository.AdicionarTarefa(tarefa);
                return _outputPort.Success(tarefa);
            }
            catch (Exception e)
            {

                return _outputPort.InvalidRequest(e.Message);
            }
        }
    }
}
