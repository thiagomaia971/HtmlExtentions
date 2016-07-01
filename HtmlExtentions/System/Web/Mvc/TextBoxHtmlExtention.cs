using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace System.Web.Mvc
{
    public static class TextBoxHtmlExtention
    {

        public static MvcHtmlString TextBoxFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            string title = null,
            string placeholder = null,
            bool autofocus = false,
            Html5InputTypes type = Html5InputTypes.Text,
            object htmlAttributes = null
            )
        {

            RouteValueDictionary rvd = new RouteValueDictionary(
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            rvd.Add("type", type.ToString());
            rvd.Add("class", "form-control");

            if (!string.IsNullOrWhiteSpace(title))
            {
                rvd.Add("title", title);
            }

            if (!string.IsNullOrWhiteSpace(placeholder))
            {
                rvd.Add("placeholder", placeholder);
            }

            if (autofocus)
            {
                rvd.Add("autofocus", "");
            }

            return InputExtensions.TextBoxFor(htmlHelper, expression, rvd);

        }

    }
}
