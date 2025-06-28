using System;
using FarmaciaTalentoTech.Model.Modelos;
using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using Dto = FarmaciaTalentoTech.Model.Dto;

namespace FarmaciaTalentoTech.WebApi.Servicios.UsuarioServicio;

public class UsuarioServicios
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly FarmaciaTalentoTechContext _farmaciaTalentoTechContext;
    private readonly IRolesRepositorio _rolRepositorio;

    public UsuarioServicios(IUsuarioRepositorio usuarioRepositorio, IRolesRepositorio rolRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _rolRepositorio = rolRepositorio;
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

    public bool ActualizarUsuarioADO(Usuario usuario)
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

    public Usuario ObtenerUsuario(string nombreUsuario)
    {
        if (string.IsNullOrWhiteSpace(nombreUsuario))
        {
            throw new ArgumentException("El nombre de usuario debe ser un valor válido.");
        }

        var usuario = _usuarioRepositorio.ObtenerUsuario(nombreUsuario);

        if (usuario == null)
        {
            throw new InvalidOperationException("El usuario no existe en la base de datos.");
        }

        return usuario;
    }

    public bool ActualizarUsuario(Dto.Usuario usuarioModificado)
    {
        if (usuarioModificado == null)
        {
            throw new ArgumentNullException(nameof(usuarioModificado), "El usuario no puede ser nulo.");
        }
        if (string.IsNullOrWhiteSpace(usuarioModificado.NombreUsuario) || string.IsNullOrWhiteSpace(usuarioModificado.Password))
        {
            throw new ArgumentException("El nombre de usuario y la contraseña son obligatorios.");
        }
        if (usuarioModificado.Id <= 0)
        {
            throw new ArgumentException("El ID del usuario debe ser un valor válido.");
        }
        // Validar que el usuario exista en la base de datos
        var usuarioDB = _usuarioRepositorio.ObtenerUsuario(usuarioModificado.NombreUsuario);
        
        if (usuarioDB == null)
        {
            throw new InvalidOperationException("El usuario no existe en la base de datos.");
        }

        if (usuarioDB.IdRole != usuarioModificado.IdRol) { 
            usuarioDB.IdRole = usuarioModificado.IdRol;
            usuarioDB.IdRoleNavigation = _rolRepositorio.ObtenerRolePorId(usuarioModificado.IdRol);
        }

        if (!usuarioDB.NombreUsuario.Equals(usuarioModificado.NombreUsuario) && 
            _usuarioRepositorio.ValidarUsuariosMismoNombre(usuarioModificado.NombreUsuario) > 0) {
            throw new InvalidOperationException("El nombre del usuario modificado ya existe.");
        }

        usuarioDB.NombreUsuario = usuarioModificado.NombreUsuario;
        usuarioDB.Password = usuarioModificado.Password;
        usuarioDB.Email = usuarioModificado.Email;
        
        return _usuarioRepositorio.ActualizarUsuario(usuarioDB);
    }
}
