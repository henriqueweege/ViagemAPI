using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto.Veiculo;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController :ControllerBase
    {
        public IVeiculoRepository Repository { get; set; }
        public IVeiculoServices Services { get; set; }

        public VeiculoController(VeiculoRepository repository, VeiculoServices services)
        {
            Repository = repository;
            Services = services;

        }

        /// <summary>
        /// Adicionar veiculo.
        /// </summary>
        /// <param name="veiculoDto">Veiculo para ser adicionado.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadVeiculoDto> AdicionarVeiculo(CreateVeiculoDto veiculoDto)
        {
            if (!Services.CheckarFormatoPlaca(veiculoDto.Placa)) return BadRequest("Placa em formato inválido.");
            var veiculoAdicionado = Repository.CriarNovoVeiculo(Services.TransformaCreateDtoEmVeiculo(veiculoDto));
            if (veiculoAdicionado != null) return Ok(Services.TransformaVeiculoEmViewModel(veiculoAdicionado));
            return BadRequest("Veiculo não adicionado.");


        }


        /// <summary>
        /// Buscar todos os veiculos.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ReadVeiculoDto>> BuscarTodosOsVeiculo()
        {

            var veiculosExistentes = Repository.BuscarTodosOsVeiculos();
            if (veiculosExistentes != null) return Ok(Services.TransformaVeiculosEmViewModelList(veiculosExistentes));
            return NotFound("Veiculos não encontrados.");

        }

        /// <summary>
        /// Buscar veiculo por id.
        /// </summary>
        /// <param name="id">Id  a ser pesquisado.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadVeiculoDto> BuscarVeiculoPorId(int id)
        {
            var veiculo = Repository.BuscarVeiculoPorId(id);
            if (veiculo != null) return Ok(Services.TransformaVeiculoEmViewModel(veiculo));
            return NotFound("Veiculo não encontrado.");
        }


        /// <summary>
        /// Buscar veiculo pela placa.
        /// </summary>
        /// <param name="placa">Placa do veiculo para pesquisar.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarVeiculoPelaPlaca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ReadVeiculoDto> BuscarVeiculoPelaPlaca(string placa)
        {
            if (!Services.CheckarFormatoPlaca(placa)) return BadRequest("Placa em formato inválido.");
            var veiculo = Repository.BuscarVeiculoPelaPlaca(placa);
            if (veiculo != null) return Ok(Services.TransformaVeiculoEmViewModel(veiculo));
            return NotFound("Veiculo não encontrado.");
        }


        /// <summary>
        /// Atualizar veiculo.
        /// </summary>
        /// <param name="veiculoDto">Veiculo a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadVeiculoDto> AtualizarVeiculo(UpdateVeiculoDto veiculoDto)
        {
            if (!Services.CheckarFormatoPlaca(veiculoDto.Placa)) return BadRequest("Placa em formato inválido.");
            var veiculoConvertido = Services.TransformaUpdateDtoEmVeiculo(veiculoDto);
            var veiculoAtualizado = Repository.AtualizarVeiculo(veiculoConvertido);
            if (veiculoAtualizado != null) return Ok(Services.TransformaVeiculoEmViewModel(veiculoAtualizado));
            return NotFound("Veiculo não encontrado.");
        }


        /// <summary>
        /// Deletar veiculo.
        /// </summary>
        /// <param name="id">Id do veiculo a ser deletado.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletarVeiculo(int id)
        {
            var deletaVeiculo = Repository.DeletarVeiculoPorId(id);
            if (deletaVeiculo) return NoContent();
            return NotFound("Veiculo não encontrado.");
        }


    }
}
