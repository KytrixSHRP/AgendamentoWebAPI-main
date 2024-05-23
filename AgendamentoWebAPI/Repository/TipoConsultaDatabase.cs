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
    public class TipoConsultaDatabase : ITipoConsultaDatabase
    {
        private readonly MySqlConnection _database;
        private readonly ILogger<TipoConsultaDatabase> _logger;
        
        public TipoConsultaDatabase(MySqlConnection database, ILogger<TipoConsultaDatabase> logger)
        {
            _database = database;
            _logger = logger;
        }
        
        public async Task<List<TipoConsulta>> EncontrarTiposConsulta(int idMedico)
        {
            try
            {
                _logger.LogInformation($"Buscando tipos de consulta para o medico com id {idMedico}...");
                
                var tiposConsulta = await _database.QueryAsync<TipoConsulta>(QueryExtensions.QueryConsultaTipoConsulta(),
                new { idMedico });
                return tiposConsulta.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }
    }
}