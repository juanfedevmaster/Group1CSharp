using FarmaciaTalentoTech.Model.Dto;
using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using FarmaciaTalentoTech.WebApi.Servicios;
using FarmaciaTalentoTech.WebApi.Servicios.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaTalentoTech.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private FarmaciaTalentoTechContext _farmaciaTalentoTech;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UserController(FarmaciaTalentoTechContext farmaciaTalentoTech, IUsuarioRepositorio usuarioRepositorio)
        {
            _farmaciaTalentoTech = farmaciaTalentoTech;
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        [Route("api/auth")]
        public IActionResult AutenticarUsuario(string nombreUsuario, string password)
        {
            var usuarioServicios = new UsuarioServicios(_usuarioRepositorio, _farmaciaTalentoTech);
            try
            {
                var usuario = usuarioServicios.Authenticar(nombreUsuario, password);
                if (usuario != null)
                {
                    return Ok(new { mensaje = "Autenticado", usuarioObjeto = UsuarioMapper.MapToUsuarioDto(usuario)});
                }
                else
                {
                    return StatusCode(401, new { mensaje = "El usuario y el password no existen en la base de datos." });
                }
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
