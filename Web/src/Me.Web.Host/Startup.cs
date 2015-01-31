namespace Me.Web.Host
{
    using Archient.Web.Identity.Domain.Controllers;
    using Archient.Web.Identity.Extensions;
    using Me.Web.Host.Controllers;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;

    // SSL & IIS Express: http://www.hanselman.com/blog/WorkingWithSSLAtDevelopmentTimeIsEasierWithIISExpress.aspx
    public class Startup : Archient.Web.Client.DefaultStarterWebStartup
    {
        public Startup(IHostingEnvironment env)
            : base(env)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services = services.AddIdentityServices(this.Configuration);

            base.ConfigureServices(services);
        }

        public override void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerfactory)
        {
            this.ConfigureWeb(app, env, loggerfactory);

            app = app.ConfigureIdentity();

            app = this.ConfigureMvc(app);
        }

        protected override IApplicationBuilder RegisterRoutes(
            IApplicationBuilder app)
        {
            var controllerNamespaces =
                new[]
                {
                    typeof(HomeController).Namespace,
                    typeof(AccountController).Namespace
                };

            return this.RegisterRoutes(app, typeof(HomeController), nameof(HomeController.Index));
        }
    }
}