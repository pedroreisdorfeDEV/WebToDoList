using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Shared.Abstractions;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Services.Repositories.Abstractions;

namespace WebToDoListKlassMatt.UseCase.ObtencaoTarefa
{
    public class ObtencaoTarefasUseCase : IObtencaoTarefas
    {
        private readonly IOutputPort _outputPort;
        private readonly IObtencaoTarefasRepository _obtencaoTarefasRepository;

        public ObtencaoTarefasUseCase(IOutputPort outputPort, IObtencaoTarefasRepository obtencaoTarefasRepository)
        {
            _outputPort = outputPort;
            _obtencaoTarefasRepository = obtencaoTarefasRepository;
        }

        public async Task<IActionResult> ExecuteAsync()
        {
            try
            {
                var response = await _obtencaoTarefasRepository.BuscarTarefas();
                return _outputPort.Success(response);
            }
            catch (Exception e)
            {

                return _outputPort.InvalidRequest(e.Message);
            }
        }
    }
}
