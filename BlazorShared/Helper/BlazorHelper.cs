using HtmlAgilityPack;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.RenderTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShared.Helper
{
    public static class BlazorHelper
    {
        public static RenderFragment RenderRawHtml(this string htmlString)
        {
            return builder =>
            {
                var doc = htmlString.HtmlDocument();
                var node = doc.DocumentNode;

                int sequence = 0;

                renderNode(builder, node, sequence);
            };
        }

        public static void renderNode(RenderTreeBuilder builder, HtmlNode node, int sequence)
        {
            switch (node.NodeType)
            {
                case HtmlNodeType.Document:
                    foreach (var child in node.ChildNodes)
                    {
                        renderNode(builder, child, sequence);
                    }
                    break;
                case HtmlNodeType.Element:
                    builder.OpenElement(sequence += 1, node.Name);

                    foreach (var attr in node.Attributes)
                        builder.AddAttribute(sequence += 1, attr.Name, attr.Value);

                    foreach (var child in node.ChildNodes)
                        renderNode(builder, child, sequence);

                    builder.CloseElement();
                    break;
                case HtmlNodeType.Text:
                    builder.AddContent(sequence += 1, node.InnerText);
                    break;
            }
        }
    }
}
