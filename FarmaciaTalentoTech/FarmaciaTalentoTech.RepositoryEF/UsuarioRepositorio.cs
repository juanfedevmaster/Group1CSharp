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
            _farmaciaTalentoTechContext.Usuarios.Update(usuario);

            try
            {
                _farmaciaTalentoTechContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario: " + ex.Message);
            }
        }
        public bool CrearUsuario(Usuario usuario)
        {
            _farmaciaTalentoTechContext.Usuarios.Add(usuario);

            try
            {
                _farmaciaTalentoTechContext.SaveChanges();
                return true;
            }
            catch (Exception ex) {
                throw new Exception("Error al crear el usuario: " + ex.Message);
            }
        }

        public bool EliminarUsuario(Usuario nombreUsuario)
        {
            _farmaciaTalentoTechContext.Usuarios.Remove(nombreUsuario);
            try
            {
                _farmaciaTalentoTechContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }

        public Usuario ObtenerUsuario(string nombreUsuario)
        {
            var usuario = _farmaciaTalentoTechContext.Usuarios
                .Include(u => u.IdRoleNavigation)
                .FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario));

            return usuario;
        }
        public Usuario AutenticarUsuario(string nombreUsuario)
        {
            var usuario = _farmaciaTalentoTechContext.Usuarios
                .Include(usuario => usuario.IdRoleNavigation)
                .FirstOrDefault(u => u.NombreUsuario.Equals(nombreUsuario));

            return usuario;
        }

        public int ValidarUsuariosMismoNombre(string nombreUsuario)
        {
            var usuariosMismoNombre = _farmaciaTalentoTechContext.Usuarios
                .Count(u => u.NombreUsuario.Equals(nombreUsuario));

            return usuariosMismoNombre;
        }
    }
}
