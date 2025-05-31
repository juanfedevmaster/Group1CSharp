using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.SingleResponsability
{
    public class ImpuestoEmpleados
    {
        public decimal CalcularImpuestoRetencionFuente(Empleado empleado)
        {
            // Lógica para calcular el impuesto del Salario 19%
            return (decimal)empleado.Salario * 0.19m;
        }

        public decimal CalcularImpuestoSolidario(Empleado empleado)
        {
            // Lógica para calcular el impuesto del Salario 10%
            return (decimal)empleado.Salario * 0.01m;
        }
    }
}
