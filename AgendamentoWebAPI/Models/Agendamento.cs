using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendamentoWebAPI.Models
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public string NomeMedico { get; set; }
        public string CrmMedico { get; set; }
        public int PacienteId { get; set; }
        public string NomePaciente { get; set; }
        public int EspecialidadeId { get; set; }
        public string Especialidade { get; set; }
        public int TipoConsultaId { get; set; }
        public string TipoConsulta { get; set; }
        public int StatusConsultaId { get; set; }
        public string StatusConsulta { get; set; }
        public DateTime DataAgendamento { get; set; }
        public string LinkConsulta { get; set;}
    }
}