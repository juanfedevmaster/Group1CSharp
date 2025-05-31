namespace EjemploPOOCopilot.Models
{
    public class Paciente : Persona
    {
        public int Edad { get; set; }

        public Paciente(string nombre, string apellido, int edad) : base(nombre, apellido)
        {
            Edad = edad;
        }
    }
}
