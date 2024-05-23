using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoWebAPI.Models
{
    public class AgendamentoCriado
    {
        public int Id { get; set; }
        public DateTime DataAgendamento { get; set; }

        public string EmailMedico { get; set; }
        public string EmailPaciente { get; set; }
    }
}