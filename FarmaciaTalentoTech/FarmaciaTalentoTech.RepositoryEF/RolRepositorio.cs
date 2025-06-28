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
    public class RolRepositorio : IRolesRepositorio
    {
        private readonly FarmaciaTalentoTechContext _farmaciaTalentoTechContext;

        public RolRepositorio(FarmaciaTalentoTechContext farmaciaTalentoTechContext)
        {
            _farmaciaTalentoTechContext = farmaciaTalentoTechContext ?? throw new ArgumentNullException(nameof(farmaciaTalentoTechContext), "El contexto de la base de datos no puede ser nulo.");
        }

        public Role ObtenerRolePorId(int idRole)
        {
            var role = _farmaciaTalentoTechContext.Roles
                .Include(r => r.Usuarios)
                .Include(r => r.IdPermisos)
                .FirstOrDefault(r => r.Id == idRole);
            
            return role;

        }
    }
}
