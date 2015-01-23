namespace Me.Web.Presentation
{
    using Me.Web.Domain.Controllers;
    using Me.Web.Domain.Entities;
    using Me.Web.Extensions;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Diagnostics;
    using Microsoft.AspNet.Diagnostics.Entity;
    using Microsoft.AspNet.Hosting;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Routing;
    using Microsoft.AspNet.Routing.Template;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;
    using Microsoft.Framework.Logging.Console;
    using System;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.Linq;

    public abstract class DefaultStarterWebStartup
    {
        protected DefaultStarterWebStartup(IHostingEnvironment env)
        {
            // Setup configuration sources.
            this.Configuration = new Configuration()
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
        }

        public virtual IConfiguration Configuration { get; set; }

        // This method gets called by the runtime.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            // Add EF services to the services container.
            services.AddEntityFramework(Configuration)
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>();

            // Add Identity services to the services container.
            services.AddIdentity<ApplicationUser, IdentityRole>(Configuration)
                .AddEntityFrameworkStores<ApplicationDbContext>();

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
            if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseBrowserLink();
                app.UseErrorPage(ErrorPageOptions.ShowAll);
                app.UseDatabaseErrorPage(DatabaseErrorPageOptions.ShowAll);
            }
            else
            {
                // Add Error handling middleware which catches all application specific errors and
                // send the request to the following path or controller action.
                app.UseErrorHandler("/Home/Error");
            }

            // Add static files to the request pipeline.
            app.UseStaticFiles();

            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            // Add MVC to the request pipeline.
            app.UseMvc(routes =>
            {
                const string DefaultRouteName = "default";
                const string DefaultRouteTemplate = "{controller}/{action}/{id?}";
                var defaultRouteDefaults = new { controller = ControllerNames.GetName<HomeController>(), action = nameof(HomeController.Index) };
                var defaultRouteNamespaces = new[] { typeof(HomeController).Namespace };

                routes = routes.MapRoute(
                    name: DefaultRouteName,
                    template: DefaultRouteTemplate,
                    defaults: defaultRouteDefaults,
                    constraints: null,
                    namespaces: defaultRouteNamespaces);

                // Uncomment the following line to add a route for porting Web API 2 controllers.
                // routes.MapWebApiRoute("DefaultApi", "api/{controller}/{id?}");
            });
        }
    }
}