using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersCompany.Models;

namespace WorkersCompany.Filtros
{
    public class FiltroSeguridad : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {


            var json = context.HttpContext.Session.GetString("usuario");
            if (json != null)
            {
                Usuario user = null;
                if ((user = JsonConvert.DeserializeObject<Usuario>(json)) != null)
                {
                    Console.WriteLine("Datos Usuario en session:" + user.ToString());
                }
                else
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login" }));
                }
            }
            else
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "Login" }));
            }

        }
    }


}
