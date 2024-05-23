using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoEspecialidadeWebAPI.Models;

namespace AgendamentoWebAPI.Repository
{
    public interface IDataHoraAgendamentoDatabase
    {
        public Task<List<DataHoraAgendamento>> BuscarDataHoraDisponiveis(int idPaciente, int idMedico, DateTime data);
    }
}