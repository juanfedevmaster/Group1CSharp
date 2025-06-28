using System;
using FarmaciaTalentoTech.Model.Modelos;
using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;

namespace FarmaciaTalentoTech.WebApi.Servicios;

public class UsuarioServicios
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly FarmaciaTalentoTechContext _farmaciaTalentoTechContext;

    public UsuarioServicios(IUsuarioRepositorio usuarioRepositorio, FarmaciaTalentoTechContext farmaciaTalentoTechContext)
    {
        this._usuarioRepositorio = usuarioRepositorio;
        this._farmaciaTalentoTechContext = farmaciaTalentoTechContext;
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

        if (usuario.Id <= 0)
        {
            throw new ArgumentException("El rol del usuario debe ser un valor válido.");
        }

        // Validar que el usuario no exista ya en la base de datos
        var usuarioExistente = _usuarioRepositorio.ObtenerUsuario(usuario.NombreUsuario);

        if (usuarioExistente != null)
        {
            throw new InvalidOperationException("El usuario ya existe en la base de datos.");
        }

        return _usuarioRepositorio.CrearUsuario(usuario);
    }

    public bool ActualizarUsuario(Usuario usuario)
    {
        if (usuario == null)
        {
            throw new ArgumentNullException(nameof(usuario), "El usuario no puede ser nulo.");
        }
        if (usuario.Id <= 0)
        {
            throw new ArgumentException("El ID del usuario debe ser un valor válido.");
        }

        if (string.IsNullOrWhiteSpace(usuario.NombreUsuario) || string.IsNullOrWhiteSpace(usuario.Password))
        {
            throw new ArgumentException("El nombre de usuario y la contraseña son obligatorios.");
        }

        // Validar que el usuario exista en la base de datos
        var usuarioExistente = _usuarioRepositorio.ObtenerUsuario(usuario.NombreUsuario);

        if (usuarioExistente == null)
        {
            throw new InvalidOperationException("El usuario no existe en la base de datos.");
        }
        return _usuarioRepositorio.ActualizarUsuario(usuario);
    }

    public bool EliminarUsuario(string nombreUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario))
        {
            throw new ArgumentException("El usuario debe ser un valor válido.");
        }
        // Validar que el usuario exista en la base de datos
        var usuarioExistente = _usuarioRepositorio.ObtenerUsuario(nombreUsuario);

        if (usuarioExistente == null)
        {
            throw new InvalidOperationException("El usuario no existe en la base de datos.");
        }

        return _usuarioRepositorio.EliminarUsuario(nombreUsuario);
    }

    public Usuario Authenticar(string nombreUsuario, string password)
    {
        var usuario = _usuarioRepositorio.AutenticarUsuario(nombreUsuario, password);
        return usuario;
    }
}
