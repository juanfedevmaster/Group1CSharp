using PrincipiosSOLID.OpenClose;
using PrincipiosSOLID.SingleResponsability;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.InterfaceSegregation
{
    public class EmpleadoRepositoryOracle : IEmpleadoRepository, IEliminarRepo
    {
        public void Actualizar(Empleado empleado)
        {
            // Lógica para actualizar el empleado en la base de datos Oracle
            Console.WriteLine($"Empleado {empleado.Nombre} {empleado.Apellido} actualizado en la base de datos Oracle.");
        }
        public void Eliminar(Empleado empleado)
        {
            // Lógica para eliminar el empleado de la base de datos Oracle
            Console.WriteLine($"Empleado {empleado.Nombre} {empleado.Apellido} eliminado de la base de datos Oracle.");
        }
        public Empleado ObtenerPorId(int id)
        {
            // Lógica para obtener el empleado por ID de la base de datos Oracle
            return new Empleado("Juan", "Pérez", "Desarrollador", 50000);
        }
        public List<Empleado> ObtenerPorPuesto(string puesto)
        {
            // Lógica para filtrar empleados por puesto en la base de datos Oracle
            return new List<Empleado>();
        }
        public List<Empleado> ObtenerPorPuesto(string puesto, double salario)
        {
            // Lógica para filtrar empleados por puesto y salario en la base de datos Oracle
            return new List<Empleado>();
        }
        public void Guardar(Empleado empleado)
        {
            // Lógica para guardar el empleado en la base de datos Oracle
            Console.WriteLine($"Empleado {empleado.Nombre} {empleado.Apellido} guardado en la base de datos Oracle.");
        }
        public List<Empleado> ObtenerTodos()
        {
            // Lógica para obtener todos los empleados de la base de datos Oracle
            return new List<Empleado>();
        }
    }
}
