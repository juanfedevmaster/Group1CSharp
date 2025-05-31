using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion.TiposDeMotor
{
    public class M30BMW : IMotor
    {
        public string Tipo { get; set; }
        public int Potencia { get; set; }
        public string Combustible { get; set; }

        public M30BMW()
        {
            Tipo = "M30";
            Potencia = 218;
            Combustible = "Gasolina";
        }
    }
}
