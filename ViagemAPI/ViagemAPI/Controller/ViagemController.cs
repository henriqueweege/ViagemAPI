using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ViagemController : ControllerBase
    {
        public IViagemRepository Repository { get; set; }
        public ViagemController(ViagemRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ViagemViewModel> AdicionarViagem(ViagemDto dto)
        {

            var viagemAdicionada = Repository.CriarNovaViagem(dto);
            if (viagemAdicionada != null) return Ok(viagemAdicionada);
            return BadRequest("Não é possível ter um número de serviço igual " +
                "ao número de serviço de outra viagem que acontece no mesmo dia.");

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ViagemViewModel>> BuscarTodasAsViagem()
        {

            var viagensExistentes = Repository.BuscarTodasAsViagens();
            if (viagensExistentes != null) return Ok(viagensExistentes);
            return NotFound("Viagem não encontrada.");

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ViagemViewModel> BuscarViagemPorId(int id)
        {
            var viagem = Repository.BuscarViagemPorId(id);
            if (viagem != null) return Ok(viagem);
            return NotFound("Viagem não encontrada.");
        }

        [HttpGet]
        [Route("BuscarViagemPorData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ViagemViewModel>> BuscarViagemPorData(DateTime dataParaBusca)
        {
            var viagem = Repository.BuscarViagemPorData(dataParaBusca);
            if (viagem != null) return Ok(viagem);
            return NotFound("Viagem não encontrada.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ViagemViewModel> AtualizarViagem(int id, ViagemDto viagemParaAtualizar)
        {
            var viagemAtualizada = Repository.AtualizarViagem(id, viagemParaAtualizar);
            if (viagemAtualizada != null) return Ok(viagemAtualizada);
            return NotFound("Viagem não encontrada.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletarViagem(int id)
        {
            var deletaViagem = Repository.DeletarViagemPorId(id);
            if (deletaViagem) return NoContent();
            return NotFound("Viagem não encontrada.");
        }
    }
}
