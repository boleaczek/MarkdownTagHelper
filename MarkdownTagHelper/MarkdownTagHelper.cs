using System;
using Converter;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MarkdownTagHelper.TagHelpers
{
    [HtmlTargetElement("markdown")]
    public class MarkdownTagHelper: TagHelper
    {
        public string Content { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent(new MarkdownConverter().ConvertMarkdown(Content));
        }
    }
}
