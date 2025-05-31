using EjemploPOO.Interfaces;
using EjemploPOO.Objetos.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPOO.Objetos
{
    public class Deportista : Persona, IBeneficios
    {
        public string TipoDeDeporte { get; set; }

        public double ObtenerDescuentoImpuestovehicular()
        {
            return ObtenerIncentivo() * CalcularDescuentos.CalcularDescuentoVehicular(this.Vehiculo);
        }

        #region [Metodos de la entidad]
        /// <summary>
        /// Metodo que permite obtener el incentivo del deportista.
        /// </summary>
        /// <returns></returns>
        public override double ObtenerIncentivo()
        {
            return 2000000 / 2;
        }

        public override double PagarImpuestos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
