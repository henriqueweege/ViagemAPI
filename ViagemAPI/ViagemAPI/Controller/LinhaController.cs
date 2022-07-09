using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LinhaController : ControllerBase
    {
        public ILinhaRepository Repository { get; set; }
        public LinhaController(LinhaRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<LinhaViewModel> AdicionarLinha(LinhaDto dto) 
        {

             var linhaAdicionada = Repository.CriarNovaLinha(dto);
             if (linhaAdicionada != null) return Ok(linhaAdicionada);
             return BadRequest("Linha não adicionada");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<LinhaViewModel>> BuscarTodasAsLinha()
        {
   
            var linhasExistentes = Repository.BuscarTodasAsLinhas();
            if(linhasExistentes != null) return Ok(linhasExistentes);
            return NotFound();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LinhaViewModel> BuscarLinhaPorId(int id)
        {
            var linha = Repository.BuscarLinhaPorId(id);
            if (linha != null) return Ok(linha);
            return NotFound();
        }

        [HttpGet]
        [Route("BuscarLinhaPorNumero/{numero}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LinhaViewModel> BuscarLinhaPorNumero(int numero)
        {
            var linha = Repository.BuscarLinhaPeloNumero(numero);
            if (linha != null) return Ok(linha);
            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<LinhaViewModel> AtualizarLinha(int id, LinhaDto linha)
        {
            var linhaAtualizada = Repository.AtualizarLinha(id, linha);
            if (linhaAtualizada != null) return Ok(linhaAtualizada);
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarLinha(int id)
        {
            var deletaLinha = Repository.DeletarLinhaPorId(id);
            if (deletaLinha != false) return NoContent();
            return NotFound();
        }

    }
}
