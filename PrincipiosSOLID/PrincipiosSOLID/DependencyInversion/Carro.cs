using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion
{
    public class Carro : Vehiculo
    {
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Color { get; set; }

        public Carro(IMotor motor) { 
            this.Motor = motor;
        }

        public override void Apagar()
        {
            Console.WriteLine($"El carro {Modelo} ha sido apagado con motor: {this.Motor.Tipo}");
        }

        public override void Encender()
        {
            Console.WriteLine($"El carro {Modelo} ha sido encendido con motor: {this.Motor.Tipo}.");
        }
    }
}
