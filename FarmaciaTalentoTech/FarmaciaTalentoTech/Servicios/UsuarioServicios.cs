using System;
using FarmaciaTalentoTech.Model.Entidades;
using FarmaciaTalentoTech.Repository.ConexionDB;

namespace FarmaciaTalentoTech.WebApi.Servicios;

public class UsuarioServicios
{
    private readonly FarmaciaTalentoTechDB FarmaciaTalentoTechDB;

    public UsuarioServicios()
    {
        this.FarmaciaTalentoTechDB = new FarmaciaTalentoTechDB();
    }
    
    public bool Authenticar(string nombreUsuario, string password)
    {
        if (FarmaciaTalentoTechDB.ObtenerUsuario(nombreUsuario, password) != null)
        {
            return true;
        }

        return false;
    }
}
