using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VVBWeb.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        private IHttpContextAccessor httpContextAccessor;

        public CustomActionFilter(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
           // throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var voornaam = httpContextAccessor.HttpContext.Session.GetString("Voornaam");
            var naam= httpContextAccessor.HttpContext.Session.GetString("Naam");
            var url = context.HttpContext.Request.Path.ToString();

            if (!url.Contains("Home/Index") && !url.Contains("Aanmelden") && string.IsNullOrEmpty(voornaam) 
                && string.IsNullOrEmpty(naam) && url != "/")
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }
    }
}
