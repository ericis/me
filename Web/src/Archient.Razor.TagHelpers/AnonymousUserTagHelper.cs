namespace Archient.Razor.TagHelpers
{
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.AspNet.Razor.TagHelpers;

    [TagName("asp-if-anonymous")]
    [ContentBehavior(ContentBehavior.Modify)]
    public class AnonymousUserTagHelper : ConditionalDisplayTagHelperBase
    {
        protected override bool IsContentDisplayed
        {
            get
            {
                // display if anonymous
                return !this.ViewContext.HttpContext.User.Identity.IsAuthenticated;
            }
        }
    }
}