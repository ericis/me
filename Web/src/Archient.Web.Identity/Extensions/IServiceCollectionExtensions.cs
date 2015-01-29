namespace Archient.Web.Identity.Extensions
{
    using Archient.Web.Identity.Domain.Entities;
    using Microsoft.AspNet.Identity;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;
    using System.Diagnostics;

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // Add EF services to the services container.
            services
                .AddEntityFramework(configuration)
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>();

            // Add Identity services to the services container.
            services
                .AddIdentity<ApplicationUser, IdentityRole>(configuration)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            return services;
        }
    }
}