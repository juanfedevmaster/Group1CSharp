namespace FunctionaParadigExample
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string FullName { get; set; }

        public Persona(string nombre, string apellido, string cedula)
        {
            Nombre = nombre;
            Apellido = apellido;
            Cedula = cedula;
        }

        public Persona() { }

        public void GetFullName()
        {
            FullName = $"{Apellido}, {Nombre}";
        }

        public static void GetCedulaYNombre(string nombre, string cedula)
        {
            Console.WriteLine($"{cedula} - {nombre}");
        }
    }
}
