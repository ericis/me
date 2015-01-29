namespace Archient.Web.Identity.Extensions
{
    using Microsoft.AspNet.Builder;

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder ConfigureIdentity(
            this IApplicationBuilder app)
        {
            // Add cookie-based authentication to the request pipeline.
            app.UseIdentity();

            return app;
        }
    }
}