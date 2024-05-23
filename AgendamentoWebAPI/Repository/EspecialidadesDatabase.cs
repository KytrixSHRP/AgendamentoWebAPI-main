using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Dapper;
using AgendamentoWebAPI.Models;
using MySqlConnector;
using AgendamentoWebAPI.Extensions;

namespace AgendamentoWebAPI.Repository
{
    public class EspecialidadesDatabase : IEspecialidadesDatabase
    {
        private readonly MySqlConnection _database;
        private readonly ILogger<EspecialidadesDatabase> _logger;

        public EspecialidadesDatabase(MySqlConnection database, ILogger<EspecialidadesDatabase> logger)
        {
            _logger = logger;
            _database = database;
        }

        public async Task<List<Especialidade>> EncontrarEspecialidades()
        {
            try
            {
                _logger.LogInformation($"Buscando especialidades...");
                
                var especialidades = await _database.QueryAsync<Especialidade>(QueryExtensions.QueryConsultaEspecialidade());
                return especialidades.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }

        public async Task<List<Especialidade>> EncontrarEspecialidadesPorMedico(int idMedico)
        {
            try
            {
                _logger.LogInformation($"Buscando especialidades para o medico com id {idMedico}...");
                
                var especialidades = await _database.QueryAsync<Especialidade>(QueryExtensions.QueryConsultaEspecialidadePorId(),
                new { idMedico });
                return especialidades.ToList();
            }

            catch(Exception ex)
            {
                _logger.LogError($"Ocorreu um erro inesperado!! Segue o erro: {ex.Message}");
                throw new Exception("Ocorreu um erro inesperado!!");
            }
        }
    }
}