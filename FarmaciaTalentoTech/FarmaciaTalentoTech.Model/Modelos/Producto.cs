using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaTalentoTech.RepositoryEF.Models;

public partial class Producto
{
    [Key]
    public int Id { get; set; }

    public double Concentracion { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    public int IdFarmaceutica { get; set; }

    public DateOnly FechaVencimiento { get; set; }

    [StringLength(50)]
    public string Cantidad { get; set; } = null!;

    [ForeignKey("IdFarmaceutica")]
    [InverseProperty("Productos")]
    public virtual Farmaceutica IdFarmaceuticaNavigation { get; set; } = null!;

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<ProductoPresentacione> ProductoPresentaciones { get; set; } = new List<ProductoPresentacione>();

    [InverseProperty("IdProductoNavigation")]
    public virtual ICollection<ProductoPrincipioActivo> ProductoPrincipioActivos { get; set; } = new List<ProductoPrincipioActivo>();
}
