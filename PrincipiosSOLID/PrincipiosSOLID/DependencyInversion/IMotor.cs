using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion
{
    public interface IMotor
    {
        string Tipo { get; set; }
        int Potencia { get; set; }
        string Combustible { get; set; }
    }
}
