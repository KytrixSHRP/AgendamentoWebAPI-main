using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgendamentoWebAPI.Models;

namespace AgendamentoWebAPI.Services
{
    public interface ITipoConsultaService
    {
        public Task<List<TipoConsulta>> EncontrarTiposConsulta(int idMedico); 
    }

}