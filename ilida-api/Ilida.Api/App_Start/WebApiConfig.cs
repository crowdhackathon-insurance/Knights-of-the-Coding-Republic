using Ilida.Api.Mappers;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Ilida.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            RegisterDependencies(config);
        }

        internal static void RegisterDependencies(HttpConfiguration config, Container container = null)
        {
            container = container ?? new Container();

            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();

            container.Register(typeof(IMapper<,>), new[] { typeof(UserDtoMapper).Assembly });

            container.RegisterWebApiControllers(config);

            // Verify registrations
            container.Verify();

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
