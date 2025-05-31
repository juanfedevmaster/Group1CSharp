using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion.TiposDeMotor
{
    public class M3BMW : IMotor
    {
        public string Tipo { get; set; }
        public int Potencia { get; set; }
        public string Combustible { get; set; }
        public M3BMW()
        {
            Tipo = "M3";
            Potencia = 420;
            Combustible = "Gasolina";
        }
    }
}
