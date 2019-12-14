/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, IEnumerable<string> items, object attributes)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (var i in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.SetInnerText(i);
                ul.InnerHtml += li.ToString();
            }
            ul.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(attributes));

            return new MvcHtmlString(ul.ToString());
        }
    }
}*/