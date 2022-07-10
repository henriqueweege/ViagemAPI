﻿using Microsoft.AspNetCore.Mvc;
using ViagemAPI.Data.Dto;
using ViagemAPI.Data.Repository;
using ViagemAPI.Data.Repository.RepositoryContracts;
using ViagemAPI.ViewModel;

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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MotoristaViewModel> AdicionarMotorista(MotoristaDto dto)
        {

            var motoristaAdicionado = Repository.CriarNovoMotorista(dto);
            if (motoristaAdicionado != null) return motoristaAdicionado;
            return BadRequest("Motorista não adicionado.");


        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<MotoristaViewModel>> BuscarTodasOsMotorista()
        {

            var motoristasExistentes = Repository.BuscarTodosOsMotoristas();
            if (motoristasExistentes != null) return Ok(motoristasExistentes);
            return NotFound("Motoristas não encontrados.");

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MotoristaViewModel> BuscarMotoristaPorId(int id)
        {
            var motorista = Repository.BuscarMotoristaPorId(id);
            if (motorista != null) return Ok(motorista);
            return NotFound("Motorista não encontrado.");
        }

        [HttpGet]
        [Route("BuscarMotoristaPeloCpf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MotoristaViewModel> BuscarMotoristaPorCpf(string cpf)
        {
            var motorista = Repository.BuscarMotoristaPeloCpf(cpf);
            if (motorista != null) return Ok(motorista);
            return NotFound("Motorista não encontrado.");
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]        
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<MotoristaViewModel> AtualizarMotorista(int id, MotoristaDto motorista)
        {
            var motoristaAtualizado = Repository.AtualizarMotorista(id, motorista);
            if (motoristaAtualizado != null) return Ok(motoristaAtualizado);
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
