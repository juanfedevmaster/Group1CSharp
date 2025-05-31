using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Motocicleta : Vehiculo
    {
        public string TipoMotor { get; set; }
        
        public Motocicleta(string marca, string matricula, string color, string modelo, int cilindrada, string tipoMotor)
            : base(marca, matricula, color, modelo, cilindrada)
        {
            TipoMotor = tipoMotor;
        }

        public Motocicleta() { }

        public override string Arrancar()
        {
            return "La motocicleta ha arrancado";
        }

        public override string Detener()
        {
            return "La motocicleta se ha detenido";
        }
    }
}
