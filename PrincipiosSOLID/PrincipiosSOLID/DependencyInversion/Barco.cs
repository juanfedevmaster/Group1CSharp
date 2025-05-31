using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion
{
    public class Barco : Vehiculo
    {
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public double Eslora { get; set; }
        public int CapacidadPasajeros { get; set; }

        public Barco(IMotor motor)
        {
            this.Motor = motor;
        }
        public override void Apagar()
        {
            Console.WriteLine($"El barco {Nombre} ha sido apagado con motor: {this.Motor.Tipo}");
        }

        public override void Encender()
        {
            Console.WriteLine($"El barco {Nombre} ha sido encendido con motor: {this.Motor.Tipo}.");
        }
    }
}
