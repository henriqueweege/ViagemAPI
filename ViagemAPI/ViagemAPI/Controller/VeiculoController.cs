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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadVeiculoDto> AdicionarVeiculo(CreateVeiculoDto dto)
        {

            var veiculoAdicionado = Repository.CriarNovoVeiculo(Services.TransformaCreateDtoEmVeiculo(dto));
            if (veiculoAdicionado != null) return Ok(Services.TransformaVeiculoEmViewModel(veiculoAdicionado));
            return BadRequest("Veiculo não adicionado.");


        }

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

        [HttpGet]
        [Route("BuscarVeiculoPelaPlaca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<ReadVeiculoDto> BuscarVeiculoPelaPlaca(string placa)
        {
            var veiculo = Repository.BuscarVeiculoPelaPlaca(placa);
            if (veiculo != null) return Ok(Services.TransformaVeiculoEmViewModel(veiculo));
            return NotFound("Veiculo não encontrado.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadVeiculoDto> AtualizarVeiculo(UpdateVeiculoDto Veiculo)
        {
            var veiculoConvertido = Services.TransformaUpdateDtoEmVeiculo(Veiculo);
            var veiculoAtualizado = Repository.AtualizarVeiculo(veiculoConvertido);
            if (veiculoAtualizado != null) return Ok(Services.TransformaVeiculoEmViewModel(veiculoAtualizado));
            return NotFound("Veiculo não encontrado.");
        }

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
