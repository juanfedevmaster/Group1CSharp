using FarmaciaTalentoTech.Model.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaTalentoTech.Model.Interfaces
{
    public interface IFarmaciaTalentoTechDB
    {
        bool CrearUsuario(Usuario usuario);
        bool ActualizarUsuario(Usuario usuario);
        bool EliminarUsuario(string nombreUsuario);
        Usuario ObtenerUsuario(string nombreUsuario, string password);
    }
}
