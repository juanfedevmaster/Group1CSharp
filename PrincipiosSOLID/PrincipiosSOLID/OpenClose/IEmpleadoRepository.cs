using PrincipiosSOLID.SingleResponsability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.OpenClose
{
    public interface IEmpleadoRepository
    {
        void Guardar(Empleado empleado);
        void Actualizar(Empleado empleado);
        Empleado ObtenerPorId(int id);
        List<Empleado> ObtenerTodos();
        List<Empleado> ObtenerPorPuesto(string puesto);
        List<Empleado> ObtenerPorPuesto(string puesto, double salario);
    }
}
