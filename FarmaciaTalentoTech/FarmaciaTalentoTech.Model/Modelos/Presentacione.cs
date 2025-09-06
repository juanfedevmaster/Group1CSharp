using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaTalentoTech.RepositoryEF.Models;

public partial class Presentacione
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Descripcion { get; set; } = null!;

    [InverseProperty("IdPresentacionNavigation")]
    public virtual ICollection<ProductoPresentacione> ProductoPresentaciones { get; set; } = new List<ProductoPresentacione>();
}
