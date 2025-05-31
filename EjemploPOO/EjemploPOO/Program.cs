using EjemploPOO.Interfaces;
using EjemploPOO.Objetos;
using System.Runtime.InteropServices;

namespace EjemploPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Persona p = new Estudiante();

            p.Id = "101458";
            p.Nombre = "Alirio";
            p.Apellido = "Garcia";
            p.Edad = 90;
            p.Genero = "Masculino";

            System.Console.WriteLine("Id: " + p.Id);
            System.Console.WriteLine("Nombre: " + p.Nombre);
            System.Console.WriteLine("Apellido: " + p.Apellido);
            System.Console.WriteLine("Edad: " + p.Edad);
            System.Console.WriteLine("Genero: " + p.Genero);

            

            System.Console.WriteLine("Incentivo: " + p.ObtenerIncentivo());
        }
    }
}
