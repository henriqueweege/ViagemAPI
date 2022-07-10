using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto.Linha;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class LinhaController : ControllerBase
    {
        public ILinhaServices Services { get; set; }
        public ILinhaRepository Repository { get; set; }
        public LinhaController(LinhaRepository repository, LinhaServices services)
        {
            Repository = repository;
            Services = services;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadLinhaDto> AdicionarLinha(CreateLinhaDto dto) 
        {
            var linhaMapeada = Services.TransformaCreateDtoEmLinha(dto);
            var linhaAdicionada = Repository.CriarNovaLinha(linhaMapeada);
             if (linhaAdicionada != null) return Ok(linhaAdicionada);
             return BadRequest("Linha não adicionada");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ReadLinhaDto>> BuscarTodasAsLinha()
        {
   
            var linhasExistentes = Repository.BuscarTodasAsLinhas();
            if(linhasExistentes != null) return Ok(Services.TransformaLinhasEmViewModelList(linhasExistentes));
            return NotFound("Linhas não encontradas.");

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadLinhaDto> BuscarLinhaPorId(int id)
        {
            var linha = Repository.BuscarLinhaPorId(id);
            if (linha != null) return Ok(Services.TransformaLinhaEmViewModel(linha));
            return NotFound("Linha não encontrada.");
        }

        [HttpGet]
        [Route("BuscarLinhaPorNumero/{numero}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadLinhaDto> BuscarLinhaPorNumero(int numero)
        {
            var linha = Repository.BuscarLinhaPeloNumero(numero);
            if (linha != null) return Ok(Services.TransformaLinhaEmViewModel(linha));
            return NotFound("Linha não encontrada.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadLinhaDto> AtualizarLinha(UpdateLinhaDto linha)
        {
            var linhaConvertida = Services.TransformaUpdateDtoEmLinha(linha);
            var linhaAtualizada = Repository.AtualizarLinha(linhaConvertida);
            if (linhaAtualizada != null) return Ok(Services.TransformaLinhaEmViewModel(linhaAtualizada));
            return NotFound("Linhas não encontrada.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletarLinha(int id)
        {
            var deletaLinha = Repository.DeletarLinhaPorId(id);
            if (deletaLinha) return NoContent();
            return NotFound();
        }

    }
}
