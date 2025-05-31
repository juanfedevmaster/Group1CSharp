using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.DependencyInversion
{
    public abstract class Vehiculo
    {
        public string Marca { get; set; }
        public string Color { get; set; }

        public IMotor Motor { get; set; }

        public abstract void Encender();
        public abstract void Apagar();
    }
}
