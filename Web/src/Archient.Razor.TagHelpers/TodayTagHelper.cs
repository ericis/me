namespace Archient.Razor.TagHelpers
{
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.AspNet.Razor.TagHelpers;
    using System;

    [TagName("asp-today")]
    [ContentBehavior(ContentBehavior.Replace)]
    public class TodayTagHelper : TagHelper
    {
        [HtmlAttributeName("utc")]
        public bool IsUTC { get; set; }

        [HtmlAttributeName("format")]
        public string Format { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = string.Empty;
            output.Content = this.IsUTC ? DateTime.UtcNow.ToString(this.Format) : DateTime.Now.ToString(this.Format);
        }
    }
}