using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;

namespace AgendamentoWebAPI.Services
{
    
    public class EspecialidadesService : IEspecialidadesService
    {
        private readonly IEspecialidadesDatabase _especialidadesDatabase;
        public EspecialidadesService(IEspecialidadesDatabase especialidadesDatabase)
        {
            _especialidadesDatabase = especialidadesDatabase;
        }
        public async Task<List<Especialidade>> EncontrarEspecialidades()
        {
            var especialidades = await _especialidadesDatabase.EncontrarEspecialidades();
            return especialidades;
        }

        public async Task<List<Especialidade>> EncontrarEspecialidadesPorMedico(int idMedico)
        {
            var especialidades = await _especialidadesDatabase.EncontrarEspecialidadesPorMedico(idMedico);
            return especialidades;
        }
    }
}