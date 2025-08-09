using System;
using FarmaciaTalentoTech.Model.Modelos;
using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using Dto = FarmaciaTalentoTech.Model.Dto;
using FarmaciaTalentoTech.WebApi.Servicios.UsuarioServicio.Mapper;
using BCrypt.Net;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FarmaciaTalentoTech.WebApi.Servicios.UsuarioServicio;

public class UsuarioServicios
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly FarmaciaTalentoTechContext _farmaciaTalentoTechContext;
    private readonly IRolesRepositorio _rolRepositorio;
    private readonly IPermisoRepositorio _permisoRepositorio;
    private readonly IConfiguration _config;

    public UsuarioServicios(IUsuarioRepositorio usuarioRepositorio, IRolesRepositorio rolRepositorio, IConfiguration config, IPermisoRepositorio permisoRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
        _rolRepositorio = rolRepositorio;
        _config = config;
        _permisoRepositorio = permisoRepositorio;
    }

    public bool CrearUsuario(Dto.Usuario usuario)
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
        var usuarioExistente = _usuarioRepositorio.ObtenerUsuario(usuario.NombreUsuario);

        if (usuarioExistente != null)
        {
            throw new InvalidOperationException("El usuario ya existe en la base de datos.");
        }

        var usuarioModelo = UsuarioMapper.MapToUsuarioModelo(usuario);
        usuarioModelo.IdRoleNavigation = _rolRepositorio.ObtenerRolePorId(usuario.IdRol);

        return _usuarioRepositorio.CrearUsuario(usuarioModelo);
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

        return _usuarioRepositorio.EliminarUsuario(usuarioExistente);
    }

    public Usuario Authenticar(string nombreUsuario, string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        var usuario = _usuarioRepositorio.AutenticarUsuario(nombreUsuario);

        if (usuario == null)
        {
            throw new InvalidOperationException("El usuario y la contraseña no existen en la base de datos.");
        }

        if (!BCrypt.Net.BCrypt.Verify(password, usuario.Password)) {
            throw new InvalidOperationException("El usuario y la contraseña no existen en la base de datos.");
        }

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
        usuarioDB.Password = BCrypt.Net.BCrypt.HashPassword(usuarioModificado.Password);
        usuarioDB.Email = usuarioModificado.Email;
        
        return _usuarioRepositorio.ActualizarUsuario(usuarioDB);
    }

    public async Task<JwtSecurityToken> GenerarJWT(Usuario usuario) { 
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var rolId = _rolRepositorio.ObtenerRolePorId(usuario.IdRole)?.Id ?? 0;
        var permisos = await _permisoRepositorio.ObtenerPermisosPorRol(rolId);

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, usuario.NombreUsuario),
            new Claim(ClaimTypes.Role, usuario.IdRoleNavigation?.Nombre)
        };

        claims.AddRange(permisos.Select(p => new Claim("Permiso", p.Nombre)));

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Int32.Parse(_config["Jwt:DuracionMinutos"])),
            signingCredentials: cred
        );

        return token;
    }
}
