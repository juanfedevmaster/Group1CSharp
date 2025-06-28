using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.Model.Modelos;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;

namespace FarmaciaTalentoTech.WebApi.Servicios.RolServicio
{
    public class RolServicio
    {
        private readonly IRolesRepositorio _roles;

        public RolServicio(IRolesRepositorio roles)
        {
            _roles = roles ?? throw new ArgumentNullException(nameof(roles), "El servicio de roles no puede ser nulo.");
        }

        public Role ObtenerRolePorId(int idRole)
        {
            if (idRole <= 0)
            {
                throw new ArgumentException("El ID del rol debe ser un valor válido.", nameof(idRole));
            }
            var role = _roles.ObtenerRolePorId(idRole);
            if (role == null)
            {
                throw new KeyNotFoundException($"No se encontró un rol con el ID {idRole}.");
            }
            return role;
        }
    }
}
