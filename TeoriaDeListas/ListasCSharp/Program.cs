using System.Text.Json.Serialization;
using System.Linq;
namespace ListasCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Ejemplo1();
            //Ejemplo2();
            Ejemplo3();
        }

        #region [Introducción a listas CSharp]
        public static void Ejemplo1()
        {
            var numeros = new List<int>();

            numeros.Add(5);
            numeros.Add(10);
            numeros.Add(15);
            numeros.Add(20);
            numeros.Add(25);
            numeros.Add(30);
            numeros.Add(35);

            // Insertar en el pricipio
            numeros.Insert(0, 100);

            // Insertar al final
            numeros.Insert(numeros.Count, 300);

            // Insertar en la mitad
            var mitad = (int)(numeros.Count / 2);
            numeros.Insert(mitad, 200);

            // Eliminar elementos
            numeros.Remove(35);
            numeros.RemoveAt(mitad);
            numeros.RemoveAt(0);
            numeros.RemoveAt(numeros.Count - 1);

            // Buscar elemento
            var index = numeros.IndexOf(35);
            Console.WriteLine($"El elemento 10 se encuentra en la posición {index}");

            var contiene = numeros.Contains(200);
            Console.WriteLine($"La lista contiene el elemento 200: {contiene}");

            var elemento = numeros.Find(x => x == 20);
            Console.WriteLine($"El elemento {elemento} fue encontrado en la lista");

            // Actualizar elemento
            var indice = numeros.IndexOf(10);
            numeros[indice] = 1000;

            var actualizar = numeros.Find(n => n == 1000);

            if (actualizar != 0)
            {
                Console.WriteLine($"El elemento {actualizar} fue encontrado en la lista");
            }
        }
        #endregion

        #region [Manejo de Predicados para Listas]

        public static void Ejemplo2()
        {
            List<int> numeros = new List<int>();

            for (var i = 0; i < 10000; i++)
            {
                Random random = new Random();
                numeros.Add(random.Next(1, 10000));
            }
            Console.WriteLine("La lista se lleno de forma correcta.");

            Console.WriteLine("Ingrese el número a buscar: ");
            int numeroCliente = Int32.Parse(Console.ReadLine());

            if (numeros.Exists(x => x == numeroCliente))
            {
                Console.WriteLine($"El número {numeroCliente} fue encontrado en la lista.");
            }
            else
            {
                Console.WriteLine($"El número {numeroCliente} no fue encontrado en la lista.");
            }

            List<int> numerosFiltrados = new List<int>();

            numerosFiltrados = numeros.FindAll(n => n > numeroCliente && n < (numeroCliente + 3000));
            Console.WriteLine($"Se encontraron {numerosFiltrados.Count} números mayores a {numeroCliente} y menores a {numeroCliente + 3000}");

        }

        #endregion

        #region [Manejo de Predicados para Listas Parte 2]

        public static void Ejemplo3()
        {
            List<string> nombres = new List<string>
            {
                "Juan", "Carlos", "José", "Luis", "Pedro", "Miguel", "Francisco", "Andrés", "Javier", "Fernando",
                "Alejandro", "Manuel", "Ricardo", "Hugo", "Diego", "Eduardo", "Gabriel", "Raúl", "David", "Antonio",
                "Ángel", "Salvador", "Sergio", "Rodrigo", "Emilio", "Martín", "Ernesto", "Roberto", "Óscar", "Esteban",
                "Iván", "Joaquín", "Gonzalo", "Alberto", "Rafael", "Tomás", "Guillermo", "Bruno", "Samuel", "Cristian",
                "Julio", "Vicente", "Emanuel", "Nicolás", "Lucas", "Héctor", "Adrián", "Simón", "Kevin", "Fabián"
            };

            List<string> nombresCompuestos = new List<string>();

            //for (int i = 0; i < nombres.Count; i++)
            //{
            //    for (int j = 0; j < nombres.Count; j++)
            //    {
            //        if (i != j)
            //        {
            //            nombresCompuestos.Add(nombres[i] + " " + nombres[j]);
            //        }
            //    }
            //}

            nombresCompuestos = nombres.SelectMany((nombre1, index1) => nombres
                .Skip(index1 + 1)
                .Select(nombre2 => nombre1 + " " + nombre2)
            ).ToList();

            foreach (var nombre in nombresCompuestos)
            {
                Console.WriteLine(nombre);
            }

        }



        #endregion
    }
}
