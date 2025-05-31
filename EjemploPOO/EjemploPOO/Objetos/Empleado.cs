using EjemploPOO.Interfaces;
using EjemploPOO.Objetos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPOO.Objetos
{
    public class Empleado : Persona, IBeneficios
    {
        public string Cargo { get; set; }
        public string Area { get; set; }
        public string JefeInmediato { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public double Salario { get; set; }

        public double ObtenerDescuentoImpuestovehicular()
        {
            return ObtenerIncentivo() * CalcularDescuentos.CalcularDescuentoVehicular(this.Vehiculo);
        }

        #region [Metodos de la entidad]

        /// <summary>
        /// Metodo que permite obtener el incentivo del empleado.
        /// </summary>
        /// <returns></returns>
        public override double ObtenerIncentivo()
        {
            return (this.Salario * 0.05) + this.Salario;
        }

        public override double PagarImpuestos()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
