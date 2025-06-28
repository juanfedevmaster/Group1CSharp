using Dto = FarmaciaTalentoTech.Model.Dto;
using Modelo = FarmaciaTalentoTech.Model.Modelos;
namespace FarmaciaTalentoTech.WebApi.Servicios.UsuarioServicio.Mapper
{
    public class UsuarioMapper
    {
        /// <summary>  
        /// Mapea un objeto Usuario a un objeto UsuarioDto.  
        /// </summary>  
        /// <param name="usuario">El objeto Usuario a mapear.</param>  
        /// <returns>Un objeto UsuarioDto con los datos del usuario.</returns>  
        public static Dto.Usuario? MapToUsuarioDto(Modelo.Usuario? usuario)
        {
            if (usuario == null)
            {
                return null;
            }

            return new Dto.Usuario
            {
                Id = usuario.Id,
                NombreUsuario = usuario.NombreUsuario,
                Email = usuario.Email,
                Password = usuario.Password,
                IdRol = usuario.IdRole,
                NombreRol = usuario.IdRoleNavigation?.Nombre ?? string.Empty,
                DescripcionRol = usuario.IdRoleNavigation?.Descripcion ?? string.Empty,
            };
        }
    }
}
