using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.Extensions.Logging;

namespace AgendamentoWebAPI.Controllers
{
    [ApiController]
    [Route("agendamentos")]
    public class AgendamentoController : Controller
    {
        private readonly ILogger<AgendamentoController> _logger;

        private readonly IAgendamentoService _agendamentoService;

        public AgendamentoController(ILogger<AgendamentoController> logger, IAgendamentoService agendamentoService)
        {
            _logger = logger;
            _agendamentoService = agendamentoService;
        }

        [HttpGet]
        [Route("paciente/{idPaciente}")]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> GetAgendamentosPaciente(int idPaciente)
        {

            var agendamentos = await _agendamentoService.EncontrarAgendamentosPaciente(idPaciente);

            if (agendamentos.Count == 0) return NotFound("Não há agendamentos a serem listados");

            return Ok(agendamentos);
        }

        [HttpGet]
        [Route("medico/{idMedico}")]
        [Authorize(Roles = "Medico")]
        public async Task<IActionResult> GetAgendamentosMedico(int idMedico)
        {

            var agendamentos = await _agendamentoService.EncontrarAgendamentosMedico(idMedico);

            if (agendamentos.Count == 0) return NotFound("Não há agendamentos a serem listados");

            return Ok(agendamentos);
        }


        [HttpPost]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> PostAgendamento([FromBody] AgendamentoForm agendamentoForm){
            var agendamentoRealizado = await _agendamentoService.CadastrarAgendamento(agendamentoForm);
            
            if(agendamentoRealizado is null) return BadRequest("Não foi possível cadastrar o agendamento");
            return Ok(agendamentoRealizado);
        }

        [HttpDelete]
        [Route("{idAgendamento}")]
        [Authorize(Roles = "Paciente,Medico")]
        public async Task<IActionResult> CancelarAgendamento(int idAgendamento)
        {

            var agendamentoCancelado = await _agendamentoService.CancelarAgendamento(idAgendamento);

            if (!agendamentoCancelado) return BadRequest("Não foi possível cancelar o agendamento");

            return Ok("Agendamento cancelado com sucesso");
        }

        [HttpGet]
        [Route("{idAgendamento}")]
        public async Task<IActionResult> GetAgendamento (int idAgendamento){
            var agendamento = await _agendamentoService.EncontrarAgendamentoPorId(idAgendamento);
            
            if (agendamento is null) return NotFound("Agendamento não encontrado");

            return Ok(agendamento);
        }

        [HttpPatch]
        [Route("{idAgendamento}")]
        public async Task<IActionResult> PatchAgendamento (int idAgendamento, [FromBody] AgendamentoForm agendamentoForm){
            var agendamentoAtualizado = await _agendamentoService.AtualizarAgendamento(idAgendamento, agendamentoForm);
            if (!agendamentoAtualizado) return BadRequest("Não é possível atualizar o agendamento");
            return Ok("Agendamento atualizado!!");
        }
    }
}