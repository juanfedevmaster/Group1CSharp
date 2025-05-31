namespace EjemploPOOCopilot.Models
{
    public abstract class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        protected Persona(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }

        public string NombreCompleto => $"{Nombre} {Apellido}";
    }
}
