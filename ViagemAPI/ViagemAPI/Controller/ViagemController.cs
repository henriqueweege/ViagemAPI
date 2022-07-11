using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto.Viagem;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class ViagemController : ControllerBase
    {
        public IViagemRepository Repository { get; set; }
        public IViagemServices Services { get; set; }
        public ViagemController(ViagemRepository repository, ViagemServices services)
        {
            Repository = repository;
            Services = services;
        }

        /// <summary>
        /// Adicionar viagem.
        /// </summary>
        /// <param name="viagemDto">Viagem para ser adicionada.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadViagemDto> AdicionarViagem(CreateViagemDto viagemDto)
        {
            if (!Repository.CheckarMesmoNumero(viagemDto.NumeroServico, viagemDto.DataPartida)) 
                return BadRequest("Números de serviço devem ser únicos no dia.");
            var viagemAdicionada = Repository.CriarNovaViagem(Services.TransformaCreateDtoEmViagem(viagemDto));
            if (viagemAdicionada != null) return Ok(viagemAdicionada);
            return BadRequest("Não é possível ter um número de serviço igual " +
                "ao número de serviço de outra viagem que acontece no mesmo dia.");

        }


        /// <summary>
        /// Buscar todas as viagens.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ReadViagemDto>> BuscarTodasAsViagem()
        {

            var viagensExistentes = Repository.BuscarTodasAsViagens();
            if (viagensExistentes != null) return Ok(viagensExistentes);
            return NotFound("Viagem não encontrada.");

        }


        /// <summary>
        /// Buscar viagem por id.
        /// </summary>
        /// <param name="id">Id  a ser pesquisado.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadViagemDto> BuscarViagemPorId(int id)
        {
            var viagem = Repository.BuscarViagemPorId(id);
            if (viagem != null) return Ok(viagem);
            return NotFound("Viagem não encontrada.");
        }


        /// <summary>
        /// Buscar viagem pela data.
        /// </summary>
        /// <param name="dataParaBusca">Data da viagem para pesquisar.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarViagemPorData")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ReadViagemDto>> BuscarViagemPorData(DateTime dataParaBusca)
        {
            var viagem = Repository.BuscarViagemPorData(dataParaBusca);
            if (viagem != null) return Ok(viagem);
            return NotFound("Viagem não encontrada.");
        }


        /// <summary>
        /// Atualizar viagem.
        /// </summary>
        /// <param name="viagemParaAtualizarDto">Viagem a ser atualizada.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadViagemDto> AtualizarViagem(UpdateViagemDto viagemParaAtualizarDto)
        {
            if (!Repository.CheckarMesmoNumero(viagemParaAtualizarDto.NumeroServico, viagemParaAtualizarDto.DataPartida)) 
                return BadRequest("Números de serviço devem ser únicos no dia.");
            var viagemParaAtualizar = Services.TransformaUpdateDtoEmViagem(viagemParaAtualizarDto);
            var viagemAtualizada = Repository.AtualizarViagem(viagemParaAtualizar);
            if (viagemAtualizada != null) return Ok(viagemAtualizada);
            return NotFound("Viagem não encontrada.");
        }


        /// <summary>
        /// Deletar viagem.
        /// </summary>
        /// <param name="id">Id da viagem a ser deletada.</param>
        /// <returns></returns>
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
