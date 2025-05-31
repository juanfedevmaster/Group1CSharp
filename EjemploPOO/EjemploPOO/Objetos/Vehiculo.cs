using EjemploPOO.Objetos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPOO.Objetos
{
    public class Vehiculo
    {
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public TipoVehiculoEnum Tipo { get; set; }

        public Vehiculo() { }
        public Vehiculo(string placa, string marca, string modelo, string color, TipoVehiculoEnum tipo)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            Tipo = tipo;
        }

    }
}
