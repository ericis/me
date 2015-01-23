namespace Me.Web.Host
{
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Hosting;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using Microsoft.Framework.Logging;

    public class Startup : Me.Web.Presentation.DefaultStarterWebStartup
    {
        public Startup(IHostingEnvironment env)
            : base(env)
        {
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            base.Configure(app, env, loggerfactory);
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
        }
    }
}