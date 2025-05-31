using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion.TiposDeMotor
{
    public class YamahaE040J : IMotor
    {
        public string Tipo { get; set; }
        public int Potencia { get; set; }
        public string Combustible { get; set; }
        public YamahaE040J()
        {
            Tipo = "Yamaha E040J";
            Potencia = 40;
            Combustible = "Gasolina";
        }
    }
}
