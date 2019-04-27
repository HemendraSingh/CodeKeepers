using MultiPlayerQuiz.Api.App_Start;
using MultiPlayerQuiz.Services;
using MultiPlayerQuiz.Services.Contracts;
using MultiPlayerQuiz.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;

namespace MultiPlayerQuiz.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            Startup.Register(container);
            container.RegisterType<IQuestionService, QuestionService>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();
            AutoMapperConfig.Initialize();

            config.MessageHandlers.Add(new TokenValidationHandler());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
