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
    public class MedicosController : Controller
    {
        private readonly ILogger<MedicosController> _logger;

        private readonly IMedicoService _medicoService;

        public MedicosController(ILogger<MedicosController> logger, IMedicoService medicoService)
        {
            _logger = logger;
            _medicoService = medicoService;
        }

        [HttpGet]
        [Authorize(Roles = "Paciente")]
        public async Task<IActionResult> GetMedicos(int idEspecialidade, int idMedico)
        {
            List<Medico> medicos = new List<Medico>();

            if (idEspecialidade == 0)
            {
                medicos = await _medicoService.EncontrarMedicos(idMedico);
            }
            else
            {
                medicos = await _medicoService.EncontrarMedicosPorEspecialidade(idEspecialidade, idMedico);
            }

            if (medicos.Count == 0) return NoContent();

            return Ok(medicos);
        }


    }
}