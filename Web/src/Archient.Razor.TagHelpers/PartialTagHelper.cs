namespace Archient.Razor.TagHelpers
{
    using Microsoft.AspNet.Mvc;
    using Microsoft.AspNet.Mvc.ModelBinding;
    using Microsoft.AspNet.Mvc.Rendering;
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.AspNet.Razor.TagHelpers;
    using System.Diagnostics;

    [TagName("asp-partial")]
    [ContentBehavior(ContentBehavior.Replace)]
    public class PartialTagHelper : TagHelper
    {
        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal ViewContext ViewContext { get; set; }

        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal IHtmlGenerator Generator { get; set; }

        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal ICompositeViewEngine ViewEngine { get; set; }

        // Protected to ensure subclasses are correctly activated. Internal for ease of use when testing.
        [Activate]
        protected internal IModelMetadataProvider ModelMetadataProvider { get; set; }

        [HtmlAttributeName("view-name")]
        public string ViewName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Debug.Assert(this.Generator != null, "expected " + nameof(this.Generator));
            Debug.Assert(this.ViewEngine != null, "expected " + nameof(this.ViewEngine));
            Debug.Assert(this.ModelMetadataProvider != null, "expected " + nameof(this.ModelMetadataProvider));

            var html = new HtmlHelper(this.Generator, this.ViewEngine, this.ModelMetadataProvider);

            html.Contextualize(this.ViewContext);

            var partial = html.Partial(this.ViewName);

            output.TagName = string.Empty;
            output.Content = partial.ToString();
        }
    }
}