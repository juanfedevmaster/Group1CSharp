using Entidades;
using Entidades.Enum;
using Persistencia;

using Newtonsoft.Json.Bson;

namespace EjemploArchivos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            Vehiculo coche = new Coche("Seat", "1234ABC", "Rojo", "Ibiza", 1600, 5);
            Vehiculo motocicleta = new Motocicleta("Yamaha", "456ABCT", "Negra", "RX115", 150, "2T");

            var almacenarObjetos = new AlmacenarObjetos("D:", "vehiculos", TipoArchivoEnum.JSON);

            for (int i = 0; i < 10; i++)
            {
                listaVehiculos.Add(coche);
            }

            almacenarObjetos.GuardarObjetoJsonLista(listaVehiculos);

            /*for (int i = 0; i < 10; i++)
            {
                bool seGuardo = almacenarObjetos.GuardarObjeto(coche, TipoVehiculoEnum.Coche);
                if (seGuardo)
                    Console.WriteLine("Vehiculo guardado correctamente");
                else
                    Console.WriteLine("Error al guardar el vehiculo");
            }*/

            //bool seGuardo = almacenarObjetos.GuardarObjeto(coche, TipoVehiculoEnum.Coche);
            //seGuardo = almacenarObjetos.GuardarObjeto(motocicleta, TipoVehiculoEnum.Motocicleta);

            //if (seGuardo)
            //    Console.WriteLine("Vehiculo guardado correctamente");
            //else
            //    Console.WriteLine("Error al guardar el vehiculo");
        }
    }
}
