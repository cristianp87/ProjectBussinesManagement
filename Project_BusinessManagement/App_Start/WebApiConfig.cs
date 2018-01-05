using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Project_BusinessManagement
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "HomeBussiness",
                routeTemplate: "api/Home/Index/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
