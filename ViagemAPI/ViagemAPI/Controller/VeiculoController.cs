using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.ViewModel;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculoController :ControllerBase
    {
        public IVeiculoRepository Repository { get; set; }
        public VeiculoController(VeiculoRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VeiculoViewModel> AdicionarVeiculo(VeiculoDto dto)
        {

            var veiculoAdicionado = Repository.CriarNovoVeiculo(dto);
            if (veiculoAdicionado != null) return Ok(veiculoAdicionado);
            return BadRequest("Veiculo não adicionado.");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<VeiculoViewModel>> BuscarTodosOsVeiculo()
        {

            var veiculosExistentes = Repository.BuscarTodosOsVeiculos();
            if (veiculosExistentes != null) return Ok(veiculosExistentes);
            return NotFound("Veiculos não encontrados.");

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VeiculoViewModel> BuscarVeiculoPorId(int id)
        {
            var veiculo = Repository.BuscarVeiculoPorId(id);
            if (veiculo != null) return Ok(veiculo);
            return NotFound("Veiculo não encontrado.");
        }

        [HttpGet]
        [Route("BuscarVeiculoPelaPlaca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]                
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<VeiculoViewModel> BuscarVeiculoPelaPlaca(string placa)
        {
            var veiculo = Repository.BuscarVeiculoPelaPlaca(placa);
            if (veiculo != null) return Ok(veiculo);
            return NotFound("Veiculo não encontrado.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VeiculoViewModel> AtualizarVeiculo(int id, VeiculoDto Veiculo)
        {
            var veiculoAtualizado = Repository.AtualizarVeiculo(id, Veiculo);
            if (veiculoAtualizado != null) return Ok(veiculoAtualizado);
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
