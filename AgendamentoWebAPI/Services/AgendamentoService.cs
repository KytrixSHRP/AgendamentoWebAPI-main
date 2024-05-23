using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;

namespace AgendamentoWebAPI.Services
{
    
    public class AgendamentoService : IAgendamentoService
    {
        private readonly IAgendamentoDatabase _agendamentoDatabase;
        public AgendamentoService(IAgendamentoDatabase agendamentoDatabase)
        {
            _agendamentoDatabase = agendamentoDatabase;
        }

        public async Task<AgendamentoCriado> CadastrarAgendamento(AgendamentoForm agendamentoForm)
        {
            var agendamentoRealizado = await _agendamentoDatabase.CadastrarAgendamento(agendamentoForm);
            if (!agendamentoRealizado) return null;

            var agendamento = await _agendamentoDatabase.BuscarAgendamentoRecemCriado();
            return agendamento;
        }

        public async Task<bool> CancelarAgendamento(int idAgendamento)
        {
            var agendamentoCancelado = await _agendamentoDatabase.CancelarAgendamento(idAgendamento);
            return agendamentoCancelado;
        }

        public async Task<List<Agendamento>> EncontrarAgendamentosMedico(int idMedico)
        {
            var agendamentos = await _agendamentoDatabase.EncontrarAgendamentosMedico(idMedico);
            return agendamentos;
        }

        public async Task<List<Agendamento>> EncontrarAgendamentosPaciente(int idPaciente)
        {
            var agendamentos = await _agendamentoDatabase.EncontrarAgendamentosPaciente(idPaciente);
            return agendamentos;
        }

        public async Task<Agendamento> EncontrarAgendamentoPorId(int idAgendamento){
            var agendamento = await _agendamentoDatabase.EncontrarAgendamentoId(idAgendamento);
            return agendamento;
        }

        public Task<bool> AtualizarAgendamento(int idAgendamento, AgendamentoForm agendamentoForm)
        {
            var atualizado = _agendamentoDatabase.AtualizarAgendamento(idAgendamento, agendamentoForm);
            return atualizado;

        }
    }
}