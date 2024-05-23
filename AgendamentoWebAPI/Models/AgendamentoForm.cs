using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoWebAPI.Models
{
    public class AgendamentoForm
    {
        public int IdMedico { get; set; }
        public int IdPaciente { get; set; }
        public int IdEspecialidade { get; set; }
        public int IdTipoConsulta { get; set; }
        public int IdStatusConsulta { get; set; }
        public DateTime DataAgendada { get; set; }
    }
}