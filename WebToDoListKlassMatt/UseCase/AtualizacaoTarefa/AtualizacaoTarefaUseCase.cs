using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.Shared.Abstractions;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Services.Repositories.Abstractions;

namespace WebToDoListKlassMatt.UseCase.AtualizacaoTarefa
{
    public class AtualizacaoTarefaUseCase : IAtualizacaoTarefa
    {
        private readonly IOutputPort _outputPort;
        private readonly IAtualizacaoTarefaRepository _atualizacaoTarefaRepository;

        public AtualizacaoTarefaUseCase(IOutputPort outputPort, IAtualizacaoTarefaRepository atualizacaoTarefaRepository)
        {
            _outputPort = outputPort;
            _atualizacaoTarefaRepository = atualizacaoTarefaRepository;
        }

        public async Task<IActionResult> ExecuteAsync(Tarefa tarefa)
        {
            try
            {
                await _atualizacaoTarefaRepository.AtualizarTarefa(tarefa);
                return _outputPort.Success(tarefa);
            }
            catch (Exception e)
            {
                return _outputPort.InvalidRequest(e.Message);
            }
        }
    }
}
