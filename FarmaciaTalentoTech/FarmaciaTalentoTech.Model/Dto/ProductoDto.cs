using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaTalentoTech.Model.Dto
{
    public class ProductoDto
    {
        public int Id { get; set; }
        public double Concentracion { get; set; }
        public string Nombre { get; set; }
        public string NombreFarmaceutica { get; set; }
        public List<string> PresentacionProducto { get; set; }
    }
}
