using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public abstract class Vehiculo
    {
        public string Marca { get; set; }
        public string Matricula { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public int Cilindrada { get; set; }

        public Vehiculo(string marca, string matricula, string color,string modelo, int cilindrada)
        {
            Marca = marca;
            Matricula = matricula;
            Color = color;
            Modelo = modelo;
            Cilindrada = cilindrada;
        }
        public Vehiculo()
        {
        }

        public abstract string Arrancar();
        public abstract string Detener();
    }
}
