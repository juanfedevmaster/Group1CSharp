using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.Model.Modelos;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaTalentoTech.RepositoryEF
{
    public class PermisoRepositorio : IPermisoRepositorio
    {
        private readonly FarmaciaTalentoTechContext _farmaciaTalentoTechContext;

        public PermisoRepositorio(FarmaciaTalentoTechContext farmaciaTalentoTechContext)
        {
            _farmaciaTalentoTechContext = farmaciaTalentoTechContext ?? throw new ArgumentNullException(nameof(farmaciaTalentoTechContext), "El contexto de la base de datos no puede ser nulo.");
        }

        public Task<List<Permiso>> ObtenerPermiso(int idPermiso)
        {
            throw new NotImplementedException();
        }

        public Task<List<Permiso>> ObtenerPermisos()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Permiso>> ObtenerPermisosPorRol(int idRol)
        {
            return await _farmaciaTalentoTechContext.Permisos
                .Where(p => p.IdRols.Any(r => r.Id == idRol)).ToListAsync();
        }
    }
}
