using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using FarmaciaTalentoTech.RepositoryEF.Models;
using FarmaciaTalentoTech.WebApi.Servicios.ProductoServicio.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaciaTalentoTech.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private FarmaciaTalentoTechContext _farmaciaTalentoTech;
        private IProductoRepositorio _productoRepositorio;
        public ProductoController(FarmaciaTalentoTechContext farmaciaTalentoTech, IProductoRepositorio productoRepositorio) {
            _farmaciaTalentoTech = farmaciaTalentoTech;
            _productoRepositorio = productoRepositorio;
        }
        [HttpGet]
        [Route("api/obtenerProductos")]
        public IActionResult ObtenerProductos() { 
            
            var productos = _productoRepositorio.obtenerProductos();
            var productosDto = ProductoMapper.MapToProductoDto(productos);
            return Ok(productosDto);
        }
    }
}
