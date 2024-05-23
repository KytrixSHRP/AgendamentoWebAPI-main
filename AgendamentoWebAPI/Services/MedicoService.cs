using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;

namespace AgendamentoWebAPI.Services
{
    
    public class MedicoService : IMedicoService
    {
        private readonly IMedicoDatabase _medicoDatabase;
        public MedicoService(IMedicoDatabase medicoDatabase)
        {
            _medicoDatabase = medicoDatabase;
        }
        public async Task<List<Medico>> EncontrarMedicos(int idMedico)
        {
            var medicos = await _medicoDatabase.EncontrarMedicos(idMedico);
            return medicos;
        }

        public async Task<List<Medico>> EncontrarMedicosPorEspecialidade(int idEspecialidade, int idMedico)
        {
            var medicos = await _medicoDatabase.EncontrarMedicoPorEspecialidade(idEspecialidade, idMedico);
            return medicos;
        }
    }
}