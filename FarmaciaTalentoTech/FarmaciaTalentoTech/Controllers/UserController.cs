using FarmaciaTalentoTech.Model.Entidades;
using FarmaciaTalentoTech.WebApi.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaTalentoTech.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("api/auth")]
        public IActionResult AutenticarUsuario(string nombreUsuario, string password)
        {
            var usuarioServicios = new UsuarioServicios();
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
            var usuarioServicios = new UsuarioServicios();
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

    }
}
