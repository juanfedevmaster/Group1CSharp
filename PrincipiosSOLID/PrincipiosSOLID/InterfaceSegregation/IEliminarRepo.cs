using PrincipiosSOLID.SingleResponsability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.InterfaceSegregation
{
    public interface IEliminarRepo
    {
        void Eliminar(Empleado empleado);
    }
}
