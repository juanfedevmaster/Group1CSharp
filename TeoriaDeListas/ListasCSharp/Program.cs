using System.Text.Json.Serialization;
using System.Linq;
namespace ListasCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numeros = new List<int>();

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

            var actualizar = numeros.Find(x => x == 1000);
            actualizar = 4000;

            for (int i = 0; i < numeros.Count; i++)
            {
                Console.WriteLine(numeros[i]);
            }
        }
    }
}
