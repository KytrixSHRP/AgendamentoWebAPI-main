using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Repository
{
    public interface IAgendamentoDatabase
    {
        public Task<List<Agendamento>> EncontrarAgendamentosPaciente(int idPaciente);
        public Task<List<Agendamento>> EncontrarAgendamentosMedico(int idMedico);
        public Task<Agendamento> EncontrarAgendamentoId(int idAgendamento);
        public Task<bool> AtualizarAgendamento(int idAgendamento, AgendamentoForm agendamentoForm);
        public Task<bool> CadastrarAgendamento(AgendamentoForm agendamentoForm);
        public Task<bool> CancelarAgendamento(int idAgendamento);
        public Task<AgendamentoCriado> BuscarAgendamentoRecemCriado();
    }
}