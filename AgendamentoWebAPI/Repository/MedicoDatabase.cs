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
    public class MedicoDatabase : IMedicoDatabase
    {
        private readonly MySqlConnection _database;
        private readonly ILogger<MedicoDatabase> _logger;
        
        public MedicoDatabase(MySqlConnection database, ILogger<MedicoDatabase> logger)
        {
            _database = database;
            _logger = logger;
        }
        
        public async Task<List<Medico>> EncontrarMedicoPorEspecialidade(int idEspecialidade, int idMedico)
        {
            try
            {
                _logger.LogInformation($"Buscando medicos para a especialidade com id {idEspecialidade}...");
                
                var medicos = await _database.QueryAsync<Medico>(QueryExtensions.QueryConsultaMedicoPorId(),
                new { idEspecialidade, idMedico });
                return medicos.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

        public async Task<List<Medico>> EncontrarMedicos(int idMedico)
        {
            try
            {
                _logger.LogInformation($"Buscando medicos...");
                
                var medicos = await _database.QueryAsync<Medico>(QueryExtensions.QueryConsultaMedico(), 
                new { idMedico });
                return medicos.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }
    }
}