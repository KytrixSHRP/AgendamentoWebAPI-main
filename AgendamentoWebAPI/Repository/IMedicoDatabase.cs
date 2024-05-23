using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Repository
{
    public interface IMedicoDatabase
    {
        public Task<List<Medico>> EncontrarMedicoPorEspecialidade(int idEspecialidade, int idMedico);
        public Task<List<Medico>> EncontrarMedicos(int idMedico);
    }
}