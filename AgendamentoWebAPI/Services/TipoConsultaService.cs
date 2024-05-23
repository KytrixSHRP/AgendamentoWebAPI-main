using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;
using AgendamentoWebAPI.Repository;

namespace AgendamentoWebAPI.Services
{
    
    public class TipoConsultaService : ITipoConsultaService
    {
        private readonly ITipoConsultaDatabase _tipoConsultaDatabase;
        public TipoConsultaService(ITipoConsultaDatabase tipoConsultaDatabase)
        {
            _tipoConsultaDatabase = tipoConsultaDatabase;
        }
        public async Task<List<TipoConsulta>> EncontrarTiposConsulta(int idMedico)
        {
            var tiposConsulta = await _tipoConsultaDatabase.EncontrarTiposConsulta(idMedico);
            return tiposConsulta;
        }
    }
}