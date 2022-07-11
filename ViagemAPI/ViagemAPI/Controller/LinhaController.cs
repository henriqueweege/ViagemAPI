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
        /// <summary>
        /// Adicionar linha.
        /// </summary>
        /// <param name="linhaDto">Linha para ser adicionada.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadLinhaDto> AdicionarLinha(CreateLinhaDto linhaDto) 
        {
            var linhaMapeada = Services.TransformaCreateDtoEmLinha(linhaDto);
            var linhaAdicionada = Repository.CriarNovaLinha(linhaMapeada);
             if (linhaAdicionada != null) return Ok(linhaAdicionada);
             return BadRequest("Linha não adicionada");


        }


        /// <summary>
        /// Buscar todas as linhas.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Buscar linha por id.
        /// </summary>
        /// <param name="id">Id  a ser pesquisado.</param>
        /// <returns></returns>
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


        /// <summary>
        /// Buscar linha por número.
        /// </summary>
        /// <param name="numero">Numero da linha para pesquisar.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarLinhaPorNumero/{numero}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ReadLinhaDto>> BuscarLinhaPorNumero(int numero)
        {
            var linha = Repository.BuscarLinhaPeloNumero(numero);
            if (linha != null) return Ok(Services.TransformaLinhasEmViewModelList(linha));
            return NotFound("Linha não encontrada.");
        }


        /// <summary>
        /// Atualizar linha.
        /// </summary>
        /// <param name="linhaDto">Linha a ser atualizada.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadLinhaDto> AtualizarLinha(UpdateLinhaDto linhaDto)
        {
            var linhaConvertida = Services.TransformaUpdateDtoEmLinha(linhaDto);
            var linhaAtualizada = Repository.AtualizarLinha(linhaConvertida);
            if (linhaAtualizada != null) return Ok(Services.TransformaLinhaEmViewModel(linhaAtualizada));
            return NotFound("Linhas não encontrada.");
        }


        /// <summary>
        /// Deletar linha.
        /// </summary>
        /// <param name="id">Id da linha a ser deletada.</param>
        /// <returns></returns>
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
