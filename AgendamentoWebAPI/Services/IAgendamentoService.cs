using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Services
{
    public interface IAgendamentoService
    {
        public Task<List<Agendamento>> EncontrarAgendamentosPaciente(int idPaciente);
        public Task<List<Agendamento>> EncontrarAgendamentosMedico(int idMedico); 
        public Task<Agendamento> EncontrarAgendamentoPorId(int idAgendamento);
        public Task<bool> AtualizarAgendamento(int idAgendamento, AgendamentoForm agendamentoForm);
        public Task<AgendamentoCriado> CadastrarAgendamento(AgendamentoForm agendamentoForm);
        public Task<bool> CancelarAgendamento(int idAgendamento);
    }

}