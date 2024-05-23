
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicoEspecialidadeWebAPI.Controllers;

[ApiController]
[Route("agendamentos/[controller]")]
public class EspecialidadesController : ControllerBase
{
    private readonly ILogger<EspecialidadesController> _logger;
    private readonly IEspecialidadesService _especialidadeService;

    public EspecialidadesController(ILogger<EspecialidadesController> logger, IEspecialidadesService especialidadesService)
    {
        _logger = logger;
        _especialidadeService = especialidadesService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEspecialidades(int idMedico)
    {
        List<Especialidade> especialidades = new List<Especialidade>();
        
        if(idMedico == 0)
        {
            especialidades = await _especialidadeService.EncontrarEspecialidades();
        }
        else
        {
            especialidades = await _especialidadeService.EncontrarEspecialidadesPorMedico(idMedico);
        }

        if (especialidades.Count == 0) return NoContent();

        return Ok(especialidades);
    }
}
