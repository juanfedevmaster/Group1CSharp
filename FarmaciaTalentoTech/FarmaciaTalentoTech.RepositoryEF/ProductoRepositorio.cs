using FarmaciaTalentoTech.Model.Interfaces;
using FarmaciaTalentoTech.RepositoryEF.DataBaseContext;
using FarmaciaTalentoTech.RepositoryEF.Models;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaTalentoTech.RepositoryEF
{
    public class ProductoRepositorio : IProductoRepositorio
    {
        private readonly FarmaciaTalentoTechContext _farmaciaTalentoTechContext;

        public ProductoRepositorio(FarmaciaTalentoTechContext farmaciaTalentoTechContext)
        {
            _farmaciaTalentoTechContext = farmaciaTalentoTechContext;
        }

        public List<Producto> obtenerProductos()
        {
            var productos = _farmaciaTalentoTechContext.Productos
                 .Include(u => u.IdFarmaceuticaNavigation)
                 .ToList();

            return productos;
        }
    }
}
