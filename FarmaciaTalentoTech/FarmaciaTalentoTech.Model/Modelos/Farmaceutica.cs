using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaTalentoTech.RepositoryEF.Models;

public partial class Farmaceutica
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Nombre { get; set; } = null!;

    [InverseProperty("IdFarmaceuticaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
