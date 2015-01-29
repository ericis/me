namespace Me.Web.Client
{
    using Archient.Web.Identity.Extensions;
    using Me.Web.Domain.Controllers;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;

    public abstract class DefaultStarterWebStartup : Archient.Web.Client.DefaultStarterWebStartup
    {
        public DefaultStarterWebStartup(IHostingEnvironment env)
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
            base.Configure(app, env, loggerfactory);

            app = app.ConfigureIdentity();
        }

        protected override IApplicationBuilder RegisterRoutes(
            IApplicationBuilder app)
        {
            return this.RegisterRoutes(app, typeof(HomeController), nameof(HomeController.Index));
        }
    }
}