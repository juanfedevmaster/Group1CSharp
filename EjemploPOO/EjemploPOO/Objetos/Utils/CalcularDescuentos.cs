using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPOO.Objetos.Utils
{
    public static class CalcularDescuentos
    {
        public static double CalcularDescuentoVehicular(Vehiculo vehiculo)
        {
            switch (vehiculo.Tipo) {
                case TipoVehiculoEnum.Electrico:
                    return 0.20;
                case TipoVehiculoEnum.Gasolina:
                    return 0.01;
                case TipoVehiculoEnum.Hibrido:
                    return 0.10;
                case TipoVehiculoEnum.Diesel:
                    return 0.01;
                case TipoVehiculoEnum.Gas:
                    return 0.02;
                case TipoVehiculoEnum.MildHybrid:
                    return 0.06;
                case TipoVehiculoEnum.PlugInHybrid:
                    return 0.15;
                case TipoVehiculoEnum.Hydrogen:
                    return 0.25;
                default:
                    return 0.01;

            }
        }
    }
}
