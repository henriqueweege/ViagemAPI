using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;

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
        public ActionResult<Veiculo> AdicionarVeiculo(VeiculoDto dto)
        {

            var veiculoAdicionado = Repository.CriarNovoVeiculo(dto);
            if (veiculoAdicionado != null) return Ok(veiculoAdicionado);
            return BadRequest("Linha não adicionada");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Veiculo>> BuscarTodasOsVeiculo()
        {

            var veiculosExistentes = Repository.BuscarTodosOsVeiculos();
            if (veiculosExistentes != null) return Ok(veiculosExistentes);
            return NotFound();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Veiculo> BuscarVeiculoPorId(int id)
        {
            var veiculo = Repository.BuscarVeiculoPorId(id);
            if (veiculo != null) return Ok(veiculo);
            return NotFound();
        }

        [HttpGet]
        [Route("BuscarVeiculoPelaPlaca")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Veiculo> BuscarVeiculoPorNumero(string cpf)
        {
            var veiculo = Repository.BuscarVeiculoPelaPlaca(cpf);
            if (veiculo != null) return Ok(veiculo);
            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Veiculo> AtualizarVeiculo(Veiculo Veiculo)
        {
            var veiculoAtualizado = Repository.AtualizarVeiculo(Veiculo);
            if (veiculoAtualizado != null) return Ok(veiculoAtualizado);
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarVeiculo(int id)
        {
            var deletaVeiculo = Repository.DeletarVeiculoPorId(id);
            if (deletaVeiculo != null) return Ok();
            return NotFound();
        }


    }
}
