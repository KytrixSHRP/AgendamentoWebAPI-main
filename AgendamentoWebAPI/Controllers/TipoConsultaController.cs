using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgendamentoWebAPI.Controllers
{
    [ApiController]
    [Route("agendamentos/[controller]")]
    public class TipoConsultaController : Controller
    {
        private readonly ILogger<TipoConsultaController> _logger;

        private readonly ITipoConsultaService _tipoConsultaService;

        public TipoConsultaController(ILogger<TipoConsultaController> logger, ITipoConsultaService tipoConsultaService)
        {
            _logger = logger;
            _tipoConsultaService = tipoConsultaService;
        }

        [HttpGet]
        [Route("{idMedico}")]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> GetTipoConsulta(int idMedico)
        {
            List<TipoConsulta> tiposConsulta = new List<TipoConsulta>();

            tiposConsulta = await _tipoConsultaService.EncontrarTiposConsulta(idMedico);

            if (tiposConsulta.Count == 0) return BadRequest("Não há tipos de consulta para este médico");

            return Ok(tiposConsulta);
        }


    }
}