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

        //[HttpPost]
        //public IActionResult AdicionaLinha(LinhaDto dto) 
        //{
        //    try
        //    {
        //        var adicionandoLinha = Repository.CriarNovaLinha(dto);
        //        if (adicionandoLinha) return Ok();
        //        return BadRequest("Linha não adicionada");
        //    }
        //    catch(Exception exception)
        //    {
        //        throw exception;
        //    }

        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Linha>> BuscaTodasAsLinha()
        {

                
            var linhasExistentes = Repository.BuscarTodasAsLinhas();
            if(linhasExistentes != null) return Ok(linhasExistentes);
            return NotFound();

        }
    }
}
