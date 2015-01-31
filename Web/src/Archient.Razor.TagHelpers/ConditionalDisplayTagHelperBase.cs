namespace Archient.Razor.TagHelpers
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;

    public abstract class ConditionalDisplayTagHelperBase : TagHelper
    {
        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal ViewContext ViewContext { get; set; }

        protected virtual bool IsTagNameDisplayed { get { return false; } }

        protected virtual bool IsContentDisplayed { get { return false; } }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!this.IsTagNameDisplayed)
                output.TagName = string.Empty;
            
            if (!this.IsContentDisplayed)
                output.Content = string.Empty;
        }
    }
}