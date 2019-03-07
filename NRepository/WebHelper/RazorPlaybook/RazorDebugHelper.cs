using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebHelper.RazorPlaybook
{


//    @Model.Categories.DebugTable()
//@Model.Videos.DebugTable(@<tr>
//    <td>@item.Id</td>
//    <td>@item.Title</td>
//    <td>@item.Description</td>
//    <td>@item.CategoryId</td>
//    <td>@item.VideoUrl</td>
//    <td>@item.CreatedAt</td>
//    <td>@item.Category.Title</td>
//    <td>@item.Level</td>
//</tr>
//)
    /// <summary>
    ///  debug helper
    /// </summary>
    public static class RazorDebugHelper
    {
        public static HelperResult DebugTable<TItem>(this IEnumerable<TItem> items)
        {
            var helperResult = new HelperResult(async writer =>
            {
                var firstItem = items.FirstOrDefault();

                writer.Write("<table>");
                writer.Write("<tr>");

                if (firstItem == null)
                {
                    return;
                }

                var properties = firstItem.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.Write("<td>" + property.Name + "</td>");
                }
                writer.Write("</tr>");

                foreach (var item in items)
                {
                    writer.Write("<tr>");

                    foreach (var property in properties)
                    {
                        writer.Write("<td>" + property.GetValue(item) + "</td>");
                    }

                    writer.Write("</tr>");
                }

                writer.Write("</table>");

            });

            return helperResult;
        }

        public static HelperResult DebugTable<TItem>(this IEnumerable<TItem> items, Func<TItem, HelperResult> template)
        {
            return new Microsoft.AspNetCore.Mvc.Razor.HelperResult(async writer =>
            {
                var firstItem = items.FirstOrDefault();

                if (firstItem == null)
                {
                    return;
                }

                writer.Write("<table>");
                writer.Write("<tr>");

                var properties = firstItem.GetType().GetProperties();

                foreach (var property in properties)
                {
                    writer.Write("<td>" + property.Name + "</td>");
                }
                writer.Write("</tr>");

                foreach (var item in items)
                {
                    foreach (var property in properties)
                    {
                        var result = template(item);
                        result.WriteTo(writer, System.Text.Encodings.Web.HtmlEncoder.Default);
                    }
                }
            }
            );
        }

        //public static string Ellipsize(this IHtmlHelper helper, string text, int ellipsisLength = 150)
        //{
        //    if (text.Length <= ellipsisLength)
        //    {
        //        return text;
        //    }
        //    else
        //    {
        //        return "<span title='" + text + "'>" + text.Substring(0, ellipsisLength) + "..." + "</span>";
        //    }
        //}


        public static HelperResult Ellipsize(this IHtmlHelper helper, string text, int ellipsisLength = 150)
        {
            return new HelperResult(async writer =>
            {
                if (text.Length <= ellipsisLength)
                {
                    writer.Write(text);
                }
                else
                {
                    writer.Write("<span title='" + text + "'>");
                    writer.Write(text.Substring(0, ellipsisLength) + "...");
                    writer.Write("</span>");
                }
            });
        }
    }

}
