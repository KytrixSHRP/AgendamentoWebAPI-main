using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using AgendamentoWebAPI.Extensions;
using AgendamentoWebAPI.Models;
using MySqlConnector;

namespace AgendamentoWebAPI.Repository
{
    public class AgendamentoDatabase : IAgendamentoDatabase
    {
        private readonly MySqlConnection _database;
        private readonly ILogger<AgendamentoDatabase> _logger;
        
        public AgendamentoDatabase(MySqlConnection database, ILogger<AgendamentoDatabase> logger)
        {
            _database = database;
            _logger = logger;
        }

        public async Task<bool> CadastrarAgendamento(AgendamentoForm agendamentoForm)
        {
            try
            {
                _logger.LogInformation($"Tentando cadastrar o agendamento no sistema...");
                
                await _database.ExecuteAsync(QueryExtensions.InserirAgendamento(),
                new {  
                    medicoId = agendamentoForm.IdMedico,
                    pacienteId = agendamentoForm.IdPaciente,
                    especialidadeId = agendamentoForm.IdEspecialidade,
                    tipoCOnsultaId = agendamentoForm.IdTipoConsulta,
                    statusId = 1,
                    dataAgendada = agendamentoForm.DataAgendada
                });

                return true;
            }

            catch(MySqlException mysqlEx){
                _logger.LogError($"Não foi possível cadastrar o agendamento: {mysqlEx.ErrorCode} {mysqlEx.Message}");
                return false;
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

        public async Task<bool> CancelarAgendamento(int idAgendamento)
        {
            try
            {
                _logger.LogInformation($"Tentando cadastrar o agendamento no sistema...");
                
                await _database.ExecuteAsync(QueryExtensions.CancelarAgendamento(),
                new {  
                    agendamentoId = idAgendamento
                });

                return true;
            }

            catch(MySqlException mysqlEx){
                _logger.LogError($"Não foi possível cancelar o agendamento: {mysqlEx.ErrorCode} {mysqlEx.Message}");
                return false;
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

        public async Task<List<Agendamento>> EncontrarAgendamentosMedico(int idMedico)
        {
            try
            {
                _logger.LogInformation($"Buscando agendamentos para o medico com id {idMedico}...");
                
                var agendamentos = await _database.QueryAsync<Agendamento>(QueryExtensions.BuscarAgendamentosMedico(),
                new { idMedico });
                return agendamentos.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

        public async Task<List<Agendamento>> EncontrarAgendamentosPaciente(int idPaciente)
        {
            try
            {
                _logger.LogInformation($"Buscando agendamentos para o paciente com id {idPaciente}...");
                
                var agendamentos = await _database.QueryAsync<Agendamento>(QueryExtensions.BuscarAgendamentosPaciente(),
                new { idPaciente });
                return agendamentos.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

        public async Task<Agendamento> EncontrarAgendamentoId(int idAgendamento)
        {
            try
            {
                _logger.LogInformation($"Buscando o agendamento com id {idAgendamento}...");
                
                var agendamento = await _database.QueryFirstOrDefaultAsync<Agendamento>(QueryExtensions.BuscarAgendamentosPorId(),
                new { idAgendamento });
                return agendamento;
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }  
        }

        public async Task<bool> AtualizarAgendamento(int idAgendamento, AgendamentoForm agendamentoForm)
        {
            try
            {
                _logger.LogInformation($"Tentando atualizar o agendamento no sistema...");
                
                await _database.ExecuteAsync(QueryExtensions.AtualizarAgendamento(),
                new {  
                    idAgendamento,
                    dataAgendada = agendamentoForm.DataAgendada
                });

                return true;
            }

            catch(MySqlException mysqlEx){
                _logger.LogError($"Não foi possível atualizar o agendamento: {mysqlEx.ErrorCode} {mysqlEx.Message}");
                return false;
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

        public async Task<AgendamentoCriado> BuscarAgendamentoRecemCriado()
        {
            try
            {
                _logger.LogInformation($"Buscando o agendamento recém criado...");
                
                var agendamento = await _database.QueryFirstOrDefaultAsync<AgendamentoCriado>(QueryExtensions.BuscarAgendamentoRecemCriado());
                return agendamento;
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }
    }
}