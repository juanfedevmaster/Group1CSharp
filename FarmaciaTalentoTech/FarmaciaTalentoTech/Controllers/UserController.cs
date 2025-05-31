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
            if (usuarioServicios.Authenticar(nombreUsuario, password)) {
                return Ok(new { mensaje = "Authenticado"});

            }

            return StatusCode(401, new { mensaje = "El usuario y el password no existen en la base de datos." });
        }

    }
}
