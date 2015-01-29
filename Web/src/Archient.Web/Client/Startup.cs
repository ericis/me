namespace Archient.Web.Client
{
    using Archient.Web.Extensions;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Diagnostics;
    using Microsoft.AspNet.Diagnostics.Entity;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Routing;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;
    using Microsoft.Framework.Logging.Console;
    using System;

    public abstract class DefaultStarterWebStartup
    {
        private static string DefaultConfigurationFileName = "config.json";

        private static string DefaultDevEnvName = "Development";

        private static string DefaultErrorHandlerVPath = "/Home/Error";

        protected DefaultStarterWebStartup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            this.Configuration = 
                new Configuration()
                    .AddJsonFile(this.ConfigurationFileName)
                    .AddEnvironmentVariables();
        }

        protected virtual string ConfigurationFileName {  get { return DefaultConfigurationFileName; } }

        protected virtual string DevelopmentEnvironmentName { get { return DefaultDevEnvName; } }

        protected virtual string ErrorHandlerPath {  get { return DefaultErrorHandlerVPath; } }

        public virtual IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            // Add MVC services to the services container.
            services.AddMvc();

            // Uncomment the following line to add Web API servcies which makes it easier to port Web API 2 controllers.
            // You need to add Microsoft.AspNet.Mvc.WebApiCompatShim package to project.json
            // services.AddWebApiConventions();

        }

        // Configure is called after ConfigureServices is called.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            // Configure the HTTP request pipeline.
            // Add the console logger.
            loggerfactory.AddConsole();

            // Add the following to the request pipeline only in development environment.
            if (string.Equals(env.EnvironmentName, this.DevelopmentEnvironmentName, StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler(this.ErrorHandlerPath);
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();
            
            app = this.RegisterRoutes(app);
        }

        protected virtual IApplicationBuilder RegisterRoutes(
            IApplicationBuilder app)
        {
            return this.RegisterRoutes(app, typeof(EmptyController), nameof(EmptyController.HttpNotFound));
        }

        protected virtual IApplicationBuilder RegisterRoutes(
            IApplicationBuilder app,
            Type defaultControllerType,
            string defaultControllerActionName)
        {
            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                const string DefaultRouteName = "default";
                const string DefaultRouteTemplate = "{controller}/{action}/{id?}";

                var defaultRouteDefaults =
                    new
                    {
                        controller = defaultControllerType.Name.Replace("Controller", string.Empty),
                        action = defaultControllerActionName
                    };

                var defaultRouteNamespaces =
                    new[] { defaultControllerType.Namespace };

                routes = routes.MapRoute(
                    name: DefaultRouteName,
                    template: DefaultRouteTemplate,
                    defaults: defaultRouteDefaults,
                    constraints: null,
                    namespaces: defaultRouteNamespaces);

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });

            return app;
        }
    }
}