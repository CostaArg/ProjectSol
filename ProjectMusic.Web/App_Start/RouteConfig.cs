﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectMusic.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            //routes.MapRoute(
            //    name: "Areas",
            //    url: "Areas/User/Controllers/{controller}/{action}/{id}",
            //    defaults: new { controller = "UserHome", action = "Index", id = UrlParameter.Optional }
            //);
        }
    }
}
