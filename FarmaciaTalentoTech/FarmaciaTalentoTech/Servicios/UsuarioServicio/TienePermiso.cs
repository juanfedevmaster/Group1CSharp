using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FarmaciaTalentoTech.WebApi.Servicios.UsuarioServicio
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class TienePermiso : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _permisoRequerido;

        public TienePermiso(string permisoRequerido)
        {
            _permisoRequerido = permisoRequerido;
        }

        public void OnAuthorization(AuthorizationFilterContext contexto) { 
            var usuario = contexto.HttpContext.User;
            if (usuario.Identity == null || !usuario.Identity.IsAuthenticated)
            {
                contexto.Result = new UnauthorizedResult();
                return;
            }

            var permisos = usuario.Claims
                .Where(c => c.Type == "Permiso")
                .Select(c => c.Value)
                .ToList();

            if (!permisos.Contains(_permisoRequerido))
            {
                contexto.Result = new ForbidResult();
            }
        }

    }
}
