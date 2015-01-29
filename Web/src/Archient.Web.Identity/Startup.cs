namespace Archient.Web.Identity
{
    using Microsoft.AspNet.Builder;
    using System.Diagnostics;

    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            Trace.TraceInformation("---------------------------------------------------------");
            Trace.TraceInformation(" IDENTITY STARTUP: Configure()");
            Trace.TraceInformation("---------------------------------------------------------");
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        }
    }
}
