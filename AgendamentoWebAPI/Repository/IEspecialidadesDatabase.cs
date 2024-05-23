using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Repository
{
    public interface IEspecialidadesDatabase
    {
        public Task<List<Especialidade>> EncontrarEspecialidadesPorMedico(int idMedico);
        public Task<List<Especialidade>> EncontrarEspecialidades();
    }
}