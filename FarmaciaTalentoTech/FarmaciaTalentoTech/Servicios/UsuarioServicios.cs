using System;
using FarmaciaTalentoTech.Model.Entidades;
using FarmaciaTalentoTech.Repository.ConexionDB;

namespace FarmaciaTalentoTech.WebApi.Servicios;

public class UsuarioServicios
{
    private readonly FarmaciaTalentoTechDB FarmaciaTalentoTechDB;

    public UsuarioServicios()
    {
        this.FarmaciaTalentoTechDB = new FarmaciaTalentoTechDB();
    }

    public bool CrearUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
        }

        if (string.IsNullOrWhiteSpace(usuario.NombreUsuario) || string.IsNullOrWhiteSpace(usuario.Password))
        {
            throw new ArgumentException("El nombre de usuario y la contraseña son obligatorios.");
        }

        if (usuario.IdRol <= 0)
        {
            throw new ArgumentException("El rol del usuario debe ser un valor válido.");
        }

        // Validar que el usuario no exista ya en la base de datos
        var usuarioExistente = FarmaciaTalentoTechDB.ObtenerUsuario(usuario.NombreUsuario, null);

        if (usuarioExistente != null)
        {
            throw new InvalidOperationException("El usuario ya existe en la base de datos.");
        }

        return FarmaciaTalentoTechDB.CrearUsuario(usuario);
    }
    
    public bool Authenticar(string nombreUsuario, string password)
    {
        if (FarmaciaTalentoTechDB.ObtenerUsuario(nombreUsuario, password) != null)
        {
            return true;
        }

        return false;
    }
}
