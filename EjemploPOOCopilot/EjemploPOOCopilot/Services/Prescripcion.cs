using EjemploPOOCopilot.Interfaces;
using EjemploPOOCopilot.Models;

namespace EjemploPOOCopilot.Services
{
    public class Prescripcion : IPrescripcion
    {
        public Paciente Paciente { get; set; }
        public Medico Medico { get; set; }
        public string Medicamento { get; set; }
        public int Dosis { get; set; }

        public Prescripcion(Paciente paciente, Medico medico, string medicamento, int dosis)
        {
            Paciente = paciente;
            Medico = medico;
            Medicamento = medicamento;
            Dosis = dosis;
        }
    }
}
