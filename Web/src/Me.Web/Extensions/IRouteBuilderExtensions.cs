namespace Me.Web.Extensions
{
    using Microsoft.AspNet.Routing;

    public static class IRouteBuilderExtensions
    {
        public static IRouteBuilder MapRoute(
            this IRouteBuilder routeBuilder,
            string name,
            string template,
            object defaults,
            object constraints,
            string[] namespaces)
        {
            return routeBuilder.MapRoute(
                name: name,
                template: template,
                defaults: defaults,
                constraints: constraints,
                dataTokens: new { namespaces = namespaces });
        }
    }
}