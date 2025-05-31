using PrincipiosSOLID.OpenClose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.SingleResponsability
{
    public class EmpleadoRespository : IEmpleadoRepository
    {
        public void Guardar(Empleado empleado)
        {
            // Lógica para guardar el empleado en la base de datos
            Console.WriteLine($"Empleado {empleado.Nombre} {empleado.Apellido} guardado en la base de datos MYSQL.");
        }

        public void Actualizar(Empleado empleado)
        {
            // Lógica para actualizar el empleado en la base de datos
            Console.WriteLine($"Empleado {empleado.Nombre} {empleado.Apellido} actualizado en la base de datos MYSQL.");
        }

        public Empleado ObtenerPorId(int id)
        {
            // Lógica para obtener el empleado por ID de la base de datos
            // Aquí se simula la obtención de un empleado
            return new Empleado("Juan", "Pérez", "Desarrollador", 50000);
        }
        public List<Empleado> ObtenerTodos()
        {
            // Lógica para obtener todos los empleados de la base de datos
            // Aquí se simula la obtención de una lista de empleados
            return new List<Empleado>
            {
                new Empleado("Juan", "Pérez", "Desarrollador", 50000),
                new Empleado("Ana", "Gómez", "Diseñadora", 40000)
            };
        }

        public List<Empleado> ObtenerPorPuesto(string puesto)
        {
            List<Empleado> empleados = ObtenerTodos();
            // Lógica para filtrar empleados por puesto
            return empleados.Where(e => e.Puesto.Equals(puesto, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Empleado> ObtenerPorPuesto(string puesto, double salario)
        {
            List<Empleado> empleados = ObtenerTodos();
            // Lógica para filtrar empleados por puesto y salario
            return empleados.Where(e => e.Puesto.Equals(puesto, StringComparison.OrdinalIgnoreCase) && e.Salario > salario).ToList();
        }

        public string getTabla()
        {
            // Lógica para obtener el nombre de la tabla
            return "Empleados";
        }
    }
}
