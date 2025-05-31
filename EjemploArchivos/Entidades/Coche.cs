using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Coche : Vehiculo
    {
        public int NumeroPuertas { get; set; }

        public Coche(string marca, string matricula, string color, string modelo, int cilindrada, int numeroPuertas) 
            : base(marca, matricula, color, modelo, cilindrada)
        {
            NumeroPuertas = numeroPuertas;
        }

        public Coche()
        {
        }

        public override string Arrancar()
        {
            return "El coche ha arrancado";
        }
        public override string Detener()
        {
            return "El coche se ha detenido";
        }
    }
}
