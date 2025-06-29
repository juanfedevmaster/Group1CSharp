﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPOO.Objetos
{
    public abstract class Persona
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string Genero { get; set; }
        public Vehiculo Vehiculo { get; set; }


        public abstract double ObtenerIncentivo();
        public abstract double PagarImpuestos();

    }
}
