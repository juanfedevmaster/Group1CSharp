using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaTalentoTech.RepositoryEF.Models;

public partial class ProductoPresentacione
{
    public int IdPresentacion { get; set; }

    public int IdProducto { get; set; }

    [Key]
    public int Id { get; set; }

    [ForeignKey("IdPresentacion")]
    [InverseProperty("ProductoPresentaciones")]
    public virtual Presentacione IdPresentacionNavigation { get; set; } = null!;

    [ForeignKey("IdProducto")]
    [InverseProperty("ProductoPresentaciones")]
    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
