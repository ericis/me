namespace Archient.Razor.TagHelpers
{
    using Microsoft.AspNet.Razor.Runtime.TagHelpers;
    using Microsoft.AspNet.Razor.TagHelpers;
    
    [TagName("asp-if")]
    [ContentBehavior(ContentBehavior.Modify)]
    public class IfTagHelper : ConditionalDisplayTagHelperBase
    {
        [HtmlAttributeName("condition")]
        public string Condition { get; set; }

        protected override bool IsContentDisplayed
        {
            get
            {
                var condition = false;

                bool.TryParse(this.Condition, out condition);

                return condition;
            }
        }
    }
}