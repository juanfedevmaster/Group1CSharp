using System;
using System.Collections.Generic;

namespace FarmaciaTalentoTech.Model.Modelos;

public partial class Permiso
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Role> IdRols { get; set; } = new List<Role>();
}
