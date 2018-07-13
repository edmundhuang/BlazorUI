using HtmlAgilityPack;

namespace BlazorShared.Helper
{
    public static class HTMLHelper
    {
        public static HtmlDocument HtmlDocument(this string HtmlString)
        {
            var document = new HtmlDocument();

            document.LoadHtml(HtmlString);

            return document;
        }

        public static HtmlNode FirstNode(this HtmlDocument document)
        {
            var node= document.DocumentNode.FirstChild;

            return node;
        }

    }
}
