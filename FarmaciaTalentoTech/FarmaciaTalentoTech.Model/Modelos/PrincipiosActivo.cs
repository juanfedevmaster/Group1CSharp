using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaTalentoTech.RepositoryEF.Models;

public partial class PrincipiosActivo
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdPrincipioActivoNavigation")]
    public virtual ICollection<ProductoPrincipioActivo> ProductoPrincipioActivos { get; set; } = new List<ProductoPrincipioActivo>();
}
