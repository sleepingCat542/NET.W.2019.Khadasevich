using NET.W._2019.Khadasevich._24._01.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NET.W._2019.Khadasevich._24._01
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            //);

            //routes.Add(new Route("handler/{*path}", new CustomRouteHandler()));

            //routes.MapRoute(
            //    name: "Hendler",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "MyHandle", id = UrlParameter.Optional }
            //);

            routes.Add(new Route("handler/{*path}", new CustomRouteHandler()));
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

    }
    // обработчик маршрута
    class CustomRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new InfoHandler();
        }
    }
}

