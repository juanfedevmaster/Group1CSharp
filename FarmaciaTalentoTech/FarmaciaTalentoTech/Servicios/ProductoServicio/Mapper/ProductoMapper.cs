using FarmaciaTalentoTech.Model.Dto;
using FarmaciaTalentoTech.RepositoryEF.Models;

namespace FarmaciaTalentoTech.WebApi.Servicios.ProductoServicio.Mapper
{
    public class ProductoMapper
    {
        public static List<ProductoDto> MapToProductoDto(List<Producto> products)
        {
            var productsDto = new List<ProductoDto>();
            foreach (var item in products) { 
                var product = new ProductoDto() { 
                    Id = item.Id,
                    Concentracion = item.Concentracion,
                    Nombre = item.Nombre,
                    NombreFarmaceutica = item.IdFarmaceuticaNavigation.Nombre
                };

                productsDto.Add(product);
            }
            return productsDto;
        }
    }
}
