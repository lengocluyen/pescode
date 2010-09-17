using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PESWeb
{
    //public class ChangeViewAddress : WebFormViewEngine 
    //{
       
    //}
    public static class Html
    {
        public static string ResolveUrl(this HtmlHelper helper, string virtualUrl)
        {
            HttpContext httpContext = System.Web.HttpContext.Current;
            string str = virtualUrl;
            if (!virtualUrl.StartsWith("~/", StringComparison.OrdinalIgnoreCase))
            {
                return str;
            }
            virtualUrl = virtualUrl.Remove(0, 2);
            string applicationPath = httpContext.Request.ApplicationPath;
            if (string.IsNullOrEmpty(applicationPath) || !applicationPath.EndsWith("/"))
            {
                applicationPath = applicationPath + "/";
            }

            return applicationPath + virtualUrl;
        } 

        public static string PagerLinks(this HtmlHelper htmlHelper, string controllerName, string actionName, int totalItems, int pageSize, int pageIndex, string cssClass, string currentPageCssClass)
        {
            int pageCount = 0;
            if (totalItems % pageSize == 0)
                pageCount = totalItems / pageSize;
            else
                pageCount = totalItems / pageSize + 1;

            var builder = new StringBuilder();
            if (String.IsNullOrEmpty(controllerName) || String.IsNullOrEmpty(actionName))
                throw new Exception("controllerName and actionName must be specified for PageLinks.");
            if (pageCount <= 1)
                return String.Empty;


            if (String.IsNullOrEmpty(cssClass)) builder.Append("<div>");
            else builder.Append(String.Format("<div class=\"{0}\">", cssClass));
            

            // calc low and high limits for numeric links
            int intLow = pageIndex - 2;
            int intHigh = pageIndex + 2;
            if (intLow < 1) intLow = 1;
            if (intHigh > pageCount) intHigh = pageCount;
            if (intHigh - intLow < 5) while ((intHigh < intLow + 4) && intHigh < pageCount) intHigh++;
            if (intHigh - intLow < 5) while ((intLow > intHigh - 4) && intLow > 1) intLow--;

            if (intLow > 1)
            {
                builder.Append("<span> ... </span>");
                builder.Append(htmlHelper.RouteLink(" 1 ", new { controller = controllerName, action = actionName, page = 1 }));
            }

            for (int x = intLow; x < intHigh + 1; x++)
            {
                // numeric links
                if (x == pageIndex)
                {
                    if (String.IsNullOrEmpty(currentPageCssClass))
                        builder.Append(" " + x + " ");
                    else builder.Append(String.Format("<span class=\"{0}\"> {1} </span>", currentPageCssClass, x));
                }
                else
                {
                    builder.Append(htmlHelper.RouteLink(" " + x.ToString() + " ", new { controller = controllerName, action = actionName, page = x }));
                }
            }
            builder.Append("</div>");

            return builder.ToString();
        }
    }
}
