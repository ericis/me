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

            //app.UseOAuthAuthentication
            //app.UseCookieAuthentication
            //app.UseMicrosoftAccountAuthentication(
            //    options =>
            //    {
            //        options.ClientId = "";
            //        options.ClientSecret = "";
            //    });
            app.UseFacebookAuthentication(
                options =>
                {
                    options.AppId = "[TODO]";
                    options.AppSecret = "[TODO]";
                });

            return app;
        }
    }
}