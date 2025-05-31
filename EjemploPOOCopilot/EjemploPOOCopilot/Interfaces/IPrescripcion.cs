using EjemploPOOCopilot.Models;

namespace EjemploPOOCopilot.Interfaces
{
    public interface IPrescripcion
    {
        Paciente Paciente { get; set; }
        Medico Medico { get; set; }
        string Medicamento { get; set; }
        int Dosis { get; set; }
    }
}
