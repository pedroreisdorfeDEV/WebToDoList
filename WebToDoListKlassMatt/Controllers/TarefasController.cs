using Microsoft.AspNetCore.Mvc;
using WebToDoListKlassMatt.Models.Entities;
using WebToDoListKlassMatt.UseCase.AdicaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.AtualizacaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.ExclusaoTarefa.Abstractions;
using WebToDoListKlassMatt.UseCase.ObtencaoTarefa.Abstractions;

namespace WebToDoListKlassMatt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : Controller
    {
        private readonly IAdicaoTarefa _adicaoTarefa;
        private readonly IObtencaoTarefas _obtencaoTarefas;
        private readonly IExclusaoTarefa _exclusaoTarefa;
        private readonly IAtualizacaoTarefa _atualizacaoTarefa;

        public TarefasController(IAdicaoTarefa adicaoTarefa, IObtencaoTarefas obtencaoTarefas,
            IExclusaoTarefa exclusaoTarefa, IAtualizacaoTarefa atualizacaoTarefa)
        {
            _adicaoTarefa = adicaoTarefa;
            _obtencaoTarefas = obtencaoTarefas; 
            _exclusaoTarefa = exclusaoTarefa;
            _atualizacaoTarefa = atualizacaoTarefa;
        }

        [HttpPost("Adicionar")]
        [ProducesResponseType(typeof(Tarefa), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarTarefa([FromBody] Tarefa tarefa)
        {
            var response = await _adicaoTarefa.ExecuteAsync(tarefa);
            return response;
        }

        [HttpGet("Obter")]
        [ProducesResponseType(typeof(List<Tarefa>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterTarefas()
        {
            var response  = await _obtencaoTarefas.ExecuteAsync();
            return response;
        }

        [HttpDelete("Excluir/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Exluir(int id)
        {

            var response = await _exclusaoTarefa.ExecuteAsync(id);
            return response;
        }

        [HttpPut("Atualizar")]
        [ProducesResponseType(typeof(Tarefa), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationError), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AtualizarTarefa([FromBody] Tarefa tarefa)
        {
            var response = await _atualizacaoTarefa.ExecuteAsync(tarefa);
            return response;
        }

    }
}
