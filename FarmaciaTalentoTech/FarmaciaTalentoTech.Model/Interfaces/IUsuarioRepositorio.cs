using FarmaciaTalentoTech.Model.Modelos;

namespace FarmaciaTalentoTech.Model.Interfaces
{
    public interface IUsuarioRepositorio
    {
        bool CrearUsuario(Usuario usuario);
        bool ActualizarUsuario(Usuario usuario);
        bool EliminarUsuario(string nombreUsuario);
        Usuario ObtenerUsuario(string nombreUsuario);
        int ValidarUsuariosMismoNombre(string nombreUsuario);
        Usuario AutenticarUsuario(string nombreUsuario, string password);
    }
}
