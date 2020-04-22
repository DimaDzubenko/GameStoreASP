﻿using System.Web.Mvc;
using System.Web.Routing;

namespace GameStore.WebUI
{
    /// <summary>
    /// Клас настройки маршрутизации.
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Game", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}