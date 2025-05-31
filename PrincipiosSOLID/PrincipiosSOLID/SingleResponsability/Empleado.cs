using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrincipiosSOLID.SingleResponsability
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Puesto { get; set; }
        public double Salario { get; set; }
        public Empleado(string nombre, string apellido, string puesto, double salario)
        {
            Nombre = nombre;
            Apellido = apellido;
            Puesto = puesto;
            Salario = salario;
        }
    }
}
