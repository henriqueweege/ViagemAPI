using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto.Motorista;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.Services;
using ViagemAPI.Services.ServicesContracts;

namespace ViagemAPI.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MotoristaController : ControllerBase
    {
        public IMotoristaRepository Repository { get; set; }
        public IMotoristaServices Services { get; set; }
        public MotoristaController(MotoristaRepository repository, MotoristaServices services)
        {
            Repository = repository;
            Services = services;

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadMotoristaDto> AdicionarMotorista(CreateMotoristaDto dto)
        {
            var motoristaMapeado = Services.TransformaCreateDtoEmMotorista(dto);
            var motoristaAdicionado = Repository.CriarNovoMotorista(motoristaMapeado);
            if (motoristaAdicionado != null) return Services.TransformaMotoristaEmViewModel(motoristaAdicionado);
            return BadRequest("Motorista não adicionado.");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ReadMotoristaDto>> BuscarTodasOsMotorista()
        {

            var motoristasExistentes = Repository.BuscarTodosOsMotoristas();
            if (motoristasExistentes != null) return Ok(Services.TransformaMotoristasEmViewModelList(motoristasExistentes));
            return NotFound("Motoristas não encontrados.");

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadMotoristaDto> BuscarMotoristaPorId(int id)
        {
            var motorista = Repository.BuscarMotoristaPorId(id);
            if (motorista != null) return Ok(Services.TransformaMotoristaEmViewModel(motorista));
            return NotFound("Motorista não encontrado.");
        }

        [HttpGet]
        [Route("BuscarMotoristaPeloCpf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadMotoristaDto> BuscarMotoristaPorCpf(string cpf)
        {
            var motorista = Repository.BuscarMotoristaPeloCpf(cpf);
            if (motorista != null) return Ok(Services.TransformaMotoristaEmViewModel(motorista));
            return NotFound("Motorista não encontrado.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadMotoristaDto> AtualizarMotorista(UpdateMotoristaDto motorista)
        {
            var motoristaConvertido = Services.TransformaUpdateDtoEmMotorista(motorista);
            var motoristaAtualizado = Repository.AtualizarMotorista(motoristaConvertido);
            if (motoristaAtualizado != null) return Ok(Services.TransformaMotoristaEmViewModel(motoristaAtualizado));
            return NotFound("Motorista não encontrado.");
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeletarMotorista(int id)
        {
            var deletaMotorista = Repository.DeletarMotoristaPorId(id);
            if (deletaMotorista) return NoContent();
            return NotFound("Motorista não encontrado.");
        }

    }
}
