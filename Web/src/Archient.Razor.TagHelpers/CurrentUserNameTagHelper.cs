namespace Archient.Razor.TagHelpers
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.AspNet.Razor.TagHelpers;
    using System.Security.Principal;

    [TagName("asp-user-name")]
    [ContentBehavior(ContentBehavior.Replace)]
    public class CurrentUserNameTagHelper : TagHelper
    {
        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = string.Empty;
            output.Content = this.ViewContext.HttpContext.User.Identity.GetUserName();
        }
    }
}