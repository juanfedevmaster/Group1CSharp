using FarmaciaTalentoTech.Model.Dto;
using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using FarmaciaTalentoTech.WebApi.Servicios.UsuarioServicio;
using FarmaciaTalentoTech.WebApi.Servicios.UsuarioServicio.Mapper;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Dto = FarmaciaTalentoTech.Model.Dto;

namespace FarmaciaTalentoTech.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private FarmaciaTalentoTechContext _farmaciaTalentoTech;
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IRolesRepositorio _rolRepositorio;
        private readonly IPermisoRepositorio _permisos;
        private readonly UsuarioServicios _usuarioServicios;

        public UserController(FarmaciaTalentoTechContext farmaciaTalentoTech, IUsuarioRepositorio usuarioRepositorio, IRolesRepositorio rolesRepositorio,
            IPermisoRepositorio permisos, IConfiguration conf)
        {
            _farmaciaTalentoTech = farmaciaTalentoTech;
            _usuarioRepositorio = usuarioRepositorio;
            _rolRepositorio = rolesRepositorio;
            _permisos = permisos;
            _usuarioServicios = new UsuarioServicios(_usuarioRepositorio, _rolRepositorio,conf,_permisos);
        }

        [HttpGet]
        [Route("api/Auth")]
        public async Task<IActionResult> AutenticarUsuario(string nombreUsuario, string password)
        {
            try
            {
                // JuanFelipe - Pass: Admin123!
                var usuario = _usuarioServicios.Authenticar(nombreUsuario, password);
                if (usuario != null)
                {
                    var token = await _usuarioServicios.GenerarJWT(usuario);

                    return Ok(new { mensaje = "Autenticado", estado = true, Jwt = new JwtSecurityTokenHandler().WriteToken(token) });
                }

                return StatusCode(401, new { mensaje = "El usuario y el password no existen en la base de datos.", estado = false });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpGet]
        [Route("api/GetUsuarioPerfil")]
        [TienePermiso("ConsultarPerfil")]
        public IActionResult GetUsuarioPerfil(string nombreUsuario)
        {
            try
            {
                var usuario = _usuarioServicios.ObtenerUsuario(nombreUsuario);
                if (usuario != null)
                {
                    return Ok(new { mensaje = "Autenticado", usuario = UsuarioMapper.MapToUsuarioDto(usuario) });
                }

                return StatusCode(401, new { mensaje = "El usuario y el password no existen en la base de datos.", estado = false });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/ActualizarUsuario")]
        [TienePermiso("ActualizarUsuario")]
        public IActionResult ActualizarUsuario(Dto.Usuario usuario)
        {
            try
            {
                var usuarioModificado = _usuarioServicios.ActualizarUsuario(usuario);
                if (usuarioModificado)
                {
                    return Ok(new { mensaje = "Usuario actualizado correctamente.", actualizado = true });
                }

                return StatusCode(500, new { mensaje = "Error al actualizar el usuario. Contacte al Administrador." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });

            }
        }

        [HttpPost]
        [Route("api/CrearUsuario")]
        [TienePermiso("CrearUsuario")]
        public IActionResult CrearUsuario(Dto.Usuario usuarioNuevo)
        {
            try
            {
                var usuarioCreado = _usuarioServicios.CrearUsuario(usuarioNuevo);
                if (usuarioCreado)
                {
                    return Ok(new { mensaje = "Usuario creado correctamente.", creado = true });
                }

                return StatusCode(500, new { mensaje = "Error al crear el usuario. Contacte al Administrador." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }

        }

        [HttpDelete]
        [Route("api/EliminarUsuario")]
        [TienePermiso("EliminarUsuario")]
        public IActionResult EliminarUsuario(string nombreUsuario)
        {
            try
            {
                var usuarioEliminado = _usuarioServicios.EliminarUsuario(nombreUsuario);
                if (usuarioEliminado)
                {
                    return Ok(new { mensaje = "Usuario eliminado correctamente.", eliminado = true });
                }

                return StatusCode(500, new { mensaje = "Error al eliminar el usuario. Contacte al Administrador." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        #region [Seccion de ADO.NET]
        /*[HttpGet]
        [Route("api/auth")]
        public async Task<IActionResult> AutenticarUsuario(string nombreUsuario, string password)
        {
            var usuarioServicios = new UsuarioServicios(_farmaciaTalentoTech);
            if (usuarioServicios.Authenticar(nombreUsuario, password))
            {
                return Ok(new { mensaje = "Authenticado" });

            }

            return StatusCode(401, new { mensaje = "El usuario y el password no existen en la base de datos." });
        }

        [HttpPost]
        [Route("api/crearUsuario")]
        public IActionResult CrearUsuario(Usuario usuario)
        {
            var usuarioServicios = new UsuarioServicios(_farmaciaTalentoTech);
            try
            {
                if (usuarioServicios.CrearUsuario(usuario))
                {
                    return Ok(new { mensaje = "Usuario creado correctamente." });
                }
                else
                {
                    return StatusCode(500, new { mensaje = "Error al crear el usuario. Contacte al Administrador." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpPut]
        [Route("api/actualizarUsuario")]
        public IActionResult ActualizarUsuario(Usuario usuario)
        {
            var usuarioServicios = new UsuarioServicios(_farmaciaTalentoTech);
            try
            {
                if (usuarioServicios.ActualizarUsuario(usuario))
                {
                    return Ok(new { mensaje = "Usuario actualizado correctamente." });
                }
                else
                {
                    return StatusCode(500, new { mensaje = "Error al actualizar el usuario. Contacte al Administrador." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("api/eliminarUsuario")]
        public IActionResult EliminarUsuario(string nombreUsuario)
        {
            var usuarioServicios = new UsuarioServicios(_farmaciaTalentoTech);
            try
            {
                if (usuarioServicios.EliminarUsuario(nombreUsuario))
                {
                    return Ok(new { mensaje = "Usuario eliminado correctamente." });
                }
                else
                {
                    return StatusCode(500, new { mensaje = "Error al eliminar el usuario. Contacte al Administrador." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }*/
        #endregion
    }
}
