namespace Archient.Web.Identity.Extensions
{
    using Archient.Web.Identity.Domain.Entities;
    using Microsoft.AspNet.Builder;
    using Microsoft.AspNet.Identity;
    using Microsoft.Framework.ConfigurationModel;
    using Microsoft.Framework.DependencyInjection;

    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            // http://www.asp.net/mvc/overview/security/create-an-aspnet-mvc-5-app-with-facebook-and-google-oauth2-and-openid-sign-on
            // http://www.asp.net/mvc/overview/security/preventing-open-redirection-attacks
            // http://www.asp.net/mvc/overview/security/aspnet-mvc-5-app-with-sms-and-email-two-factor-authentication

            // Add EF services to the services container.
            services
                .AddEntityFramework(configuration)
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>();
            
            // Add Identity services to the services container.
            services
                .AddIdentity<ApplicationUser, IdentityRole>(configuration)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // OAuth Providers
            // https://github.com/aspnet/Identity/blob/dev/samples/IdentitySample.Mvc/Startup.cs
            // http://www.asp.net/mvc/overview/older-versions/using-oauth-providers-with-mvc
            // http://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-deploy-aspnet-mvc-app-membership-oauth-sql-database/
            // http://www.jerriepelser.com/blog/pretty-social-login-buttons-for-asp-net-mvc-5

            //services.ConfigureMicrosoftAccountAuthentication(
            //    options =>
            //    {
            //        options.ClientId = configuration.Get("Identity:Microsoft:ClientId");
            //        options.ClientSecret = configuration.Get("Identity:Microsoft:ClientSecret");
            //    });

            // https://developers.facebook.com/
            services.ConfigureFacebookAuthentication(
                options =>
                {
                    options.Scope.Add("public_profile");
                    options.Scope.Add("email");
                    options.Scope.Add("user_friends");

                    options.AppId = configuration.Get("Identity:Facebook:AppId");
                    options.AppSecret = configuration.Get("Identity:Facebook:AppSecret");
                });

            // https://console.developers.google.com/project
            services.ConfigureGoogleAuthentication(
                options =>
                {
                    options.ClientId = configuration.Get("Identity:Google:ClientId");
                    options.ClientSecret = configuration.Get("Identity:Google:ClientSecret");
                });

            // https://apps.twitter.com/
            services.ConfigureTwitterAuthentication(
                options =>
                {
                    options.ConsumerKey = configuration.Get("Identity:Twitter:ConsumerKey");
                    options.ConsumerSecret = configuration.Get("Identity:Twitter:ConsumerSecret");
                });

            return services;
        }
    }
}