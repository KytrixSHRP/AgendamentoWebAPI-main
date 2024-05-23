using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicoEspecialidadeWebAPI.Models;

namespace AgendamentoWebAPI.Services
{
    public interface IDataHoraAgendamentoService
    {
        public Task<List<DataHoraAgendamento>> BuscarDataHoraDisponiveis(int idPaciente, int idMedico);
    }
}