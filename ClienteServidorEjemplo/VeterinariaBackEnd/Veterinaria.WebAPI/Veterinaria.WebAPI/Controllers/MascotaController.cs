using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Veterinaria.WebAPI.DTOs;

namespace Veterinaria.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        [HttpGet]
        [Route("api/GetMascotas")]
        public IActionResult GetMascotas()
        {
            try
            {
                var mascotas = GenerarMascotasAleatorias();
                return Ok(mascotas);
            }
            catch (Exception e) {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error, Comuniquese con el administrador" });
            }
        }

        private List<MascotaDTO> GenerarMascotasAleatorias()
        {
            var nombres = new[] { "Max", "Luna", "Charlie", "Bella", "Rocky" };
            var especies = new[] { "Perro", "Gato", "Conejo", "Ave", "Pez" };
            var razas = new[] { "Labrador", "Siames", "Angora", "Canario", "Goldfish" };

            var random = new Random();
            var mascotas = new List<MascotaDTO>();

            for (int i = 0; i < 5; i++)
            {
                mascotas.Add(new MascotaDTO
                {
                    Id = i + 1,
                    Nombre = nombres[random.Next(nombres.Length)],
                    Especie = especies[random.Next(especies.Length)],
                    Raza = razas[random.Next(razas.Length)],
                    FechaNacimiento = DateTime.Now.AddYears(-random.Next(1, 10)).AddDays(-random.Next(1, 365))
                });
            }

            return mascotas;
        }
    }
}
