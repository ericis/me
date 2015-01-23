namespace Me.Web.Extensions
{
    using Microsoft.AspNet.Mvc;

    public static class ControllerNames
    {
        public static string GetName(this Controller controller)
        {
            return nameof(controller).Replace("Controller", string.Empty);
        }

        public static string GetName<T>()
            where T : Controller
        {
            return typeof(T).Name.Replace("Controller", string.Empty);
        }
    }
}