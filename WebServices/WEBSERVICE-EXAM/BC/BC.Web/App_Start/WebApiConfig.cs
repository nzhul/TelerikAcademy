using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

namespace BC.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Games",
                routeTemplate: "api/games/{id}",
                defaults: new { controller = "Games" }
            );

            config.Routes.MapHttpRoute(
                name: "GamesGuess",
                routeTemplate: "api/games/{id}/guess",
                defaults: new { 
                    controller = "Games",
                    action = "Guess"
                }
            );

            config.Routes.MapHttpRoute(
                name: "Scores",
                routeTemplate: "api/scores",
                defaults: new { controller = "Score" }
            );

            config.Routes.MapHttpRoute(
                name: "Notifications",
                routeTemplate: "api/notifications",
                defaults: new { controller = "Notifications" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
