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
        /// <summary>
        /// Adicionar motorista.
        /// </summary>
        /// <param name="motoristaDto">Motorista para ser adicionado.</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadMotoristaDto> AdicionarMotorista(CreateMotoristaDto motoristaDto)
        {
            if (!Services.CheckarFormatoCpf(motoristaDto.Cpf)) return BadRequest("Cpf em formato inválido.");
            if (Repository.CheckarSeCpfEstaDiponivel(motoristaDto.Cpf)) return BadRequest("Cpf já cadastrado.");
            var motoristaMapeado = Services.TransformaCreateDtoEmMotorista(motoristaDto);
            var motoristaAdicionado = Repository.CriarNovoMotorista(motoristaMapeado);
            if (motoristaAdicionado != null) return Services.TransformaMotoristaEmViewModel(motoristaAdicionado);
            return BadRequest("Motorista não adicionado.");


        }


        /// <summary>
        /// Buscar todos os  motoristas.
        /// </summary>
        /// <returns></returns>
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


        /// <summary>
        /// Buscar motorista por id.
        /// </summary>
        /// <param name="id">Id  a ser pesquisado.</param>
        /// <returns></returns>
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


        /// <summary>
        /// Buscar motorista por Cpf.
        /// </summary>
        /// <param name="cpf">Cpf do motorista para pesquisar.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("BuscarMotoristaPeloCpf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadMotoristaDto> BuscarMotoristaPorCpf(string cpf)
        {
            if (!Services.CheckarFormatoCpf(cpf)) return BadRequest("Cpf em formato inválido.");
            var motorista = Repository.BuscarMotoristaPeloCpf(cpf);
            if (motorista != null) return Ok(Services.TransformaMotoristaEmViewModel(motorista));
            return NotFound("Motorista não encontrado.");
        }


        /// <summary>
        /// Atualizar motorista.
        /// </summary>
        /// <param name="motoristaDto">Motorista a ser atualizado.</param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<ReadMotoristaDto> AtualizarMotorista(UpdateMotoristaDto motoristaDto)
        {
            if (!Services.CheckarFormatoCpf(motoristaDto.Cpf)) return BadRequest("Cpf em formato inválido.");
            var motoristaConvertido = Services.TransformaUpdateDtoEmMotorista(motoristaDto);
            var motoristaAtualizado = Repository.AtualizarMotorista(motoristaConvertido);
            if (motoristaAtualizado != null) return Ok(Services.TransformaMotoristaEmViewModel(motoristaAtualizado));
            return NotFound("Motorista não encontrado.");
        }


        /// <summary>
        /// Deletar motorista.
        /// </summary>
        /// <param name="id">Id do motorista a ser deletado.</param>
        /// <returns></returns>
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
