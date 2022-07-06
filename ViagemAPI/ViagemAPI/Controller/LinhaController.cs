using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;

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
        public ActionResult<Linha> AdicionarLinha(LinhaDto dto) 
        {

             var linhaAdicionada = Repository.CriarNovaLinha(dto);
             if (linhaAdicionada != null) return Ok(linhaAdicionada);
             return BadRequest("Linha não adicionada");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Linha>> BuscarTodasAsLinha()
        {
   
            var linhasExistentes = Repository.BuscarTodasAsLinhas();
            if(linhasExistentes != null) return Ok(linhasExistentes);
            return NotFound();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Linha> BuscarLinhaPorId(int id)
        {
            var linha = Repository.BuscarLinhaPorId(id);
            if (linha != null) return Ok(linha);
            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Linha> AtualizarLinha(Linha linha)
        {
            var linhaAtualizada = Repository.AtualizarLinha(linha);
            if (linhaAtualizada != null) return Ok(linhaAtualizada);
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarLinha(int id)
        {
            var linhaDeletada = Repository.DeletarLinhaPorId(id);
            if (linhaDeletada != null) return Ok();
            return NotFound();
        }

        [HttpGet]
        [Route("BuscarLinhaPorNumero/{numero}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Linha> BuscarLinhaPorNumero(int numero)
        {
            var linha = Repository.BuscarLinhaPeloNumero(numero);
            if (linha != null) return Ok(linha);
            return NotFound();
        }
    }
}
