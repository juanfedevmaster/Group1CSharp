using FarmaciaTalentoTech.Model.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaTalentoTech.Model.Interfaces
{
    public interface IRolesRepositorio
    {
        Role ObtenerRolePorId(int idRole);
    }
}
