using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Model;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MotoristaController : ControllerBase
    {
        public IMotoristaRepository Repository { get; set; }
        public MotoristaController(MotoristaRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Motorista> AdicionarMotorista(MotoristaDto dto)
        {

            var motoristaAdicionado = Repository.CriarNovoMotorista(dto);
            if (motoristaAdicionado != null) return Ok(motoristaAdicionado);
            return BadRequest("Linha não adicionada");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Motorista>> BuscarTodasOsMotorista()
        {

            var motoristasExistentes = Repository.BuscarTodosOsMotoristas();
            if (motoristasExistentes != null) return Ok(motoristasExistentes);
            return NotFound();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Motorista> BuscarMotoristaPorId(int id)
        {
            var motorista = Repository.BuscarMotoristaPorId(id);
            if (motorista != null) return Ok(motorista);
            return NotFound();
        }

        [HttpGet]
        [Route("BuscarMotoristaPeloCpf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Motorista> BuscarMotoristaPorNumero(string cpf)
        {
            var motorista = Repository.BuscarMotoristaPeloCpf(cpf);
            if (motorista != null) return Ok(motorista);
            return NotFound();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Motorista> AtualizarMotorista(Motorista motorista)
        {
            var motoristaAtualizado = Repository.AtualizarMotorista(motorista);
            if (motoristaAtualizado != null) return Ok(motoristaAtualizado);
            return NotFound();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarMotorista(int id)
        {
            var deletaMotorista = Repository.DeletarMotoristaPorId(id);
            if (deletaMotorista != null) return Ok();
            return NotFound();
        }

    }
}
