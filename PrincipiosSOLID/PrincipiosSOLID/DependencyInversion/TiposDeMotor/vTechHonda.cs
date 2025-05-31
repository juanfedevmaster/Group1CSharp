using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion.TiposDeMotor
{
    public class vTechHonda : IMotor
    {
        public string Tipo { get; set; }
        public int Potencia { get; set; }
        public string Combustible { get; set; }

        public vTechHonda()
        {
            Tipo = "VTEC";
            Potencia = 200;
            Combustible = "Gasolina";
        }
    }
}
