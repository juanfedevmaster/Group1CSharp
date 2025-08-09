using FarmaciaTalentoTech.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaTalentoTech.Model.Interfaces
{
    public interface IPermisoRepositorio
    {
        Task<List<Permiso>> ObtenerPermisos();
        Task<List<Permiso>> ObtenerPermisosPorRol(int idRol);
        Task<List<Permiso>> ObtenerPermiso(int idPermiso);
    }
}
