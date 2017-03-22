using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Bot.Builder.Dialogs.Internals;
using System.Reflection;
using System.Web.Http;
using DynamicDialogBot.Modules;

namespace DynamicDialogBot
{
    public partial class WebApiConfig
    {
        public static void RegisterBot(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // Register bot builder modules.
            builder.RegisterModule(new DialogModule());
            builder.RegisterModule(new DynamicDialogModule());

            // Register API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Create the container and assign the dependency resolver.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}