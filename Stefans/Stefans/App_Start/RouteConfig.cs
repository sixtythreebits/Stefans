﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Stefans
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection Routes)
        {
            Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Stefans.Controllers" }
            );
        }
    }
}
