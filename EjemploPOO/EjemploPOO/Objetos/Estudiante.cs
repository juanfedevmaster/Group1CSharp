using EjemploPOO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPOO.Objetos
{
    public class Estudiante : Persona
    {
        public string Matricula { get; set; }
        public string Carrera { get; set; }
        public string Semestre { get; set; }
        public string Grupo { get; set; }
        public string Turno { get; set; }
        public string Campus { get; set; }

        #region [Metodos de la entidad]
        /// <summary>
        /// Metodo que permite obtener el incentivo del empleado.
        /// </summary>
        /// <returns></returns>
        public override double ObtenerIncentivo()
        {
            return 1623500 / 2;
        }

        public override double PagarImpuestos()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
