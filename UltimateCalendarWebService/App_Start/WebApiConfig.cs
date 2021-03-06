﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UltimateCalendarWebService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "UltimateCalendarDefault",
                routeTemplate: "UltimateCalendarDefault/{action}/{id}",
                defaults: new { controller = "UltimateCalendarDefault", action = "Get", id = RouteParameter.Optional }
                );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
