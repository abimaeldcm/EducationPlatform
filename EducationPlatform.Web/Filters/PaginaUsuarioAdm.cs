using EducationPlatform.Web.Domain.Entity;
using EducationPlatform.Web.Domain.Entity.Enum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace EducationPlatform.Web.Filters
{
    public class PaginaUsuarioAdm : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuaro = context.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuaro))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
            }
            else
            {
                UserOutput usuario = JsonConvert.DeserializeObject<UserOutput>(sessaoUsuaro);

                if (usuario == null || usuario.AccessLevel != EAccessLevel.Manager)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
