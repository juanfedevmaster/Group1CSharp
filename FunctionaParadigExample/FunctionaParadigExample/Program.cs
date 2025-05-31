namespace FunctionaParadigExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Persona> personas = new List<Persona>();
            string[] nombres = { "Juan", "Pedro", "María", "Ana", "Luis", "Carlos", "Laura", "Elena", "Jorge", "Carmen" };
            string[] apellidos = { "Gómez", "Rodríguez", "Pérez", "Fernández", "López", "Díaz", "Martínez", "Romero", "Sánchez", "Torres" };

          
            for (int i = 0; i < 100; i++)
            {
                Random random = new Random();
                int randomNombres = random.Next(0, nombres.Length);
                int randomApellido = random.Next(0, apellidos.Length);
                personas.Add(new Persona(nombres[randomNombres], apellidos[randomApellido], (i + 1).ToString()));
            }

            for(int i = 0; i < personas.Count; i++)
            {
                personas[i].GetFullName();
                Console.WriteLine(personas[i].FullName);
            }
        }
    }
}
