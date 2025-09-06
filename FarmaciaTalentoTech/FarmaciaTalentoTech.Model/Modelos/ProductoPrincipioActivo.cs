using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaTalentoTech.RepositoryEF.Models;

[Table("ProductoPrincipioActivo")]
public partial class ProductoPrincipioActivo
{
    public int IdProducto { get; set; }

    public int IdPrincipioActivo { get; set; }

    [Key]
    public int Id { get; set; }

    [ForeignKey("IdPrincipioActivo")]
    [InverseProperty("ProductoPrincipioActivos")]
    public virtual PrincipiosActivo IdPrincipioActivoNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("ProductoPrincipioActivos")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
