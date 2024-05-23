using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Services
{
    public interface IMedicoService
    {
        public Task<List<Medico>> EncontrarMedicos(int idMedico);
        public Task<List<Medico>> EncontrarMedicosPorEspecialidade(int idEspecialidade, int idMedico); 
    }

}