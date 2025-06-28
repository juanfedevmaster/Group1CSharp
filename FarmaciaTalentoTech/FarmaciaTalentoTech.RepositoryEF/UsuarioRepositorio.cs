using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.Model.Modelos;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using Microsoft.EntityFrameworkCore;
namespace FarmaciaTalentoTech.RepositoryEF
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly FarmaciaTalentoTechContext _farmaciaTalentoTechContext;

        public UsuarioRepositorio(FarmaciaTalentoTechContext farmaciaTalentoTechContext)
        {
            _farmaciaTalentoTechContext = farmaciaTalentoTechContext;
        }

        public bool ActualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool CrearUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public bool EliminarUsuario(string nombreUsuario)
        {
            throw new NotImplementedException();
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            throw new NotImplementedException();
        }
        public Usuario AutenticarUsuario(string nombreUsuario, string password)
        {
            var usuario = _farmaciaTalentoTechContext.Usuarios
                .Include(usuario => usuario.IdRoleNavigation)
                .FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario) && u.Password.Equals(password));

            return usuario;
        }
    }
}
