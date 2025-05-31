using EjemploPOOCopilot.Interfaces;
using EjemploPOOCopilot.Models;

namespace EjemploPOOCopilot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Paciente paciente = new Paciente("Juan", "Perez", 30);
            Medico medico = new Medico("Dra. Ana", "Gomez", "Cardiología");

            IPrescripcion prescripcion = medico.PrescribirMedicamento(paciente, "Aspirina", 2);

            Console.WriteLine($"Paciente: {paciente.NombreCompleto}, Edad: {paciente.Edad}");
            Console.WriteLine($"Medico: {medico.NombreCompleto}, Especialidad: {medico.Especialidad}");
            Console.WriteLine($"Prescripción: {prescripcion.Medicamento}, Dosis: {prescripcion.Dosis} veces al día");
        }
    }
}
