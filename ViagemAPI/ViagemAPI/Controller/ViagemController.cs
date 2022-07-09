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
        public ActionResult<ViagemViewModel> AdicionarViagem(ViagemDto dto)
        {

            var viagemAdicionada = Repository.CriarNovaViagem(dto);
            if (viagemAdicionada != null) return Ok(viagemAdicionada);
            return BadRequest("Viagem não adicionada");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ViagemViewModel>> BuscarTodasAsViagem()
        {

            var viagensExistentes = Repository.BuscarTodasAsViagens();
            if (viagensExistentes != null) return Ok(viagensExistentes);
            return NotFound();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ViagemViewModel> BuscarViagemPorId(int id)
        {
            var viagem = Repository.BuscarViagemPorId(id);
            if (viagem != null) return Ok(viagem);
            return NotFound();
        }

        [HttpGet]
        [Route("BuscarViagemPorData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<ViagemViewModel>> BuscarViagemPorData(DateTime dataParaBusca)
        {
            var viagem = Repository.BuscarViagemPorData(dataParaBusca);
            if (viagem != null) return Ok(viagem);
            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ViagemViewModel> AtualizarViagem(int id, ViagemDto viagemParaAtualizar)
        {
            var viagemAtualizada = Repository.AtualizarViagem(id, viagemParaAtualizar);
            if (viagemAtualizada != null) return Ok(viagemAtualizada);
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarViagem(int id)
        {
            var deletaViagem = Repository.DeletarViagemPorId(id);
            if (deletaViagem != false) return Ok();
            return NotFound();
        }
    }
}
