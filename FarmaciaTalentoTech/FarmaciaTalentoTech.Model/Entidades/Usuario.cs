using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmaciaTalentoTech.Model.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
        public Usuario() { }
        public Usuario(int id, string nombreUsuario, string email, string password, int idRol)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            Email = email;
            Password = password;
            IdRol = idRol;
        }
    }
}
