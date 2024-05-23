using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Services;
using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendamentoWebAPI.Controllers
{
    [ApiController]
    [Route("agendamentos/[controller]")]
    public class DataHoraController : ControllerBase
    {
        private readonly ILogger<DataHoraController> _logger;
        private readonly IDataHoraAgendamentoService _dataHoraAgendamentoService;

        public DataHoraController(ILogger<DataHoraController> logger, IDataHoraAgendamentoService dataHoraAgendamentoService)
        {
            _logger = logger;
            _dataHoraAgendamentoService = dataHoraAgendamentoService;
        }

        [HttpGet]
        [Route("paciente/{idPaciente}/medico/{idMedico}")]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> GetDataHora(int idPaciente, int idMedico)
        {
            var dataHoras =  await _dataHoraAgendamentoService.BuscarDataHoraDisponiveis(idPaciente, idMedico);
            if (dataHoras.Count == 0) return NoContent();
            
            return Ok(dataHoras);
        }

    }
}