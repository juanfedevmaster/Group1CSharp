using FarmaciaTalentoTech.Model.Dto;
using FarmaciaTalentoTech.RepositoryEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaTalentoTech.Model.Interfaces
{
    public interface IProductoRepositorio
    {
        List<Producto> obtenerProductos();
    }
}
