using EjemploPOOCopilot.Interfaces;
using EjemploPOOCopilot.Services;

namespace EjemploPOOCopilot.Models
{
    public class Medico : Persona
    {
        public string Especialidad { get; set; }

        public Medico(string nombre, string apellido, string especialidad) : base(nombre, apellido)
        {
            Especialidad = especialidad;
        }

        public IPrescripcion PrescribirMedicamento(Paciente paciente, string medicamento, int dosis)
        {
            return new Prescripcion(paciente, this, medicamento, dosis);
        }
    }
}
