namespace LinqEjemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var personas = new List<Persona>();

            #region Llenado de datos de ejemplo
            var nombres = new[] {
                "Juan", "Ana", "Carlos", "Lucía", "Pedro", "María", "Luis", "Sofía", "Javier", "Valentina",
                "Diego", "Camila", "Andrés", "Elena", "Miguel", "Paula", "David", "Juliana", "Fernando", "Carla",
                "Esteban", "Gabriela", "Tomás", "Daniela", "Álvaro"
            };

            var apellidos = new[] {
                "García", "Martínez", "Rodríguez", "López", "Pérez", "Gómez", "Sánchez", "Díaz", "Ramírez", "Torres",
                "Flores", "Jiménez", "Morales", "Ruiz", "Hernández", "Castro", "Ortiz", "Vargas", "Ramos", "Silva",
                "Navarro", "Mendoza", "Cruz", "Herrera", "Reyes"
            };

            var rnd = new Random();

            for (int i = 1; i <= 50; i++)
            {
                var persona = new Persona
                {
                    Id = i,
                    Nombre = nombres[rnd.Next(nombres.Length)],
                    Apellido = apellidos[rnd.Next(apellidos.Length)]
                };

                personas.Add(persona);

                //Console.WriteLine($"Id: {persona.Id}, Nombre: {persona.Nombre}, Apellido: {persona.Apellido}");
            }
            #endregion

            // Ejemplo de uso de LINQ para filtrar personas por nombre

            var personaBuscada = personas
                .FirstOrDefault(p => p.Nombre.Equals("Juan"));

            if (personaBuscada != null)
            {
                Console.WriteLine($"Id: {personaBuscada.Id}, Nombre: {personaBuscada.Nombre}, Apellido: {personaBuscada.Apellido}");
            }
        }
    }
}
