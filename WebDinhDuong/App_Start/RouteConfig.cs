using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebDinhDuong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "Cart",
            url: "tiep-tuc-mua",
            defaults: new { controller = "MonAn", action = "MonAn", id = UrlParameter.Optional },
            namespaces: new[] { "WebDinhDuong.Controllers" }


        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
