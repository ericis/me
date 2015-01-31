namespace Archient.Razor.TagHelpers
{
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.AspNet.Razor.TagHelpers;

    [TagName("asp-if-authenticated")]
    [ContentBehavior(ContentBehavior.Modify)]
    public class AuthenticatedUserTagHelper : ConditionalDisplayTagHelperBase
    {
        protected override bool IsContentDisplayed
        {
            get
            {
                // display if authenticated
                return this.ViewContext.HttpContext.User.Identity.IsAuthenticated;
            }
        }
    }
}