using HtmlExtentions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class ButtonHtmlExtention
    {

        /// <summary>
        /// Create an Image with innerHtml, buttonType, htmlAttributes.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="innerHtml">Display name</param>
        /// <param name="buttonType">Button type</param>
        /// <param name="htmlAttributes">Html Attributes</param>
        /// <returns></returns>
        public static MvcHtmlString Button(this HtmlHelper htmlHelper,
           string innerHtml,
           HtmlButtonTypes buttonType = null,
           object htmlAttributes = null
           )
        {
            return ButtonHtmlExtention.Button(htmlHelper, innerHtml, string.Empty, string.Empty, string.Empty, buttonType, htmlAttributes);
        }

        /// <summary>
        /// Create an Image with innerHtml, cssClasses, buttonType, htmlAttributes.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="innerHtml">Display name</param>
        /// <param name="cssClass">Class for CSS</param>
        /// <param name="buttonType">Button type</param>
        /// <param name="htmlAttributes">Html Attributes</param>
        /// <returns></returns>
        public static MvcHtmlString Button(this HtmlHelper htmlHelper,
          string innerHtml,
          string cssClass,
          HtmlButtonTypes buttonType = null,
          object htmlAttributes = null
          )
        {
            return ButtonHtmlExtention.Button(htmlHelper, innerHtml, cssClass, string.Empty, string.Empty, buttonType, htmlAttributes);
        }

        /// <summary>
        /// Create an Image with innerHtml, cssClasses, name, buttonType, htmlAttributes.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="innerHtml">Display name</param>
        /// <param name="cssClass">Class for CSS</param>
        /// <param name="name">Name and Id</param>
        /// <param name="buttonType">Button type</param>
        /// <param name="htmlAttributes">Html Attributes</param>
        /// <returns></returns>
        public static MvcHtmlString Button(this HtmlHelper htmlHelper,
          string innerHtml,
          string cssClass,
          string name,
          HtmlButtonTypes buttonType = null,
          object htmlAttributes = null
          )
        {
            return ButtonHtmlExtention.Button(htmlHelper, innerHtml, cssClass, name, string.Empty, buttonType, htmlAttributes);
        }


        /// <summary>
        /// Create an Image with innerHtml, cssClasses, name, glyphicon, buttonType, htmlAttributes.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="innerHtml">Display name</param>
        /// <param name="cssClass">Class for CSS</param>
        /// <param name="name">Name and Id</param>
        /// <param name="glyphicon">Glyphicon Boostrap Class</param>
        /// <param name="buttonType">Button type</param>
        /// <param name="htmlAttributes">Html Attributes</param>
        /// <returns></returns>
        public static MvcHtmlString Button(this HtmlHelper htmlHelper,
            string innerHtml,
            string cssClass,
            string name,
            string glyphicon,
            HtmlButtonTypes buttonType = null,
            object htmlAttributes = null
            )
        {
            TagBuilder tb = new TagBuilder("button");

            if (!string.IsNullOrWhiteSpace(cssClass))
            {
                if (!cssClass.Contains("btn-"))
                {
                    cssClass = "btn-primary " + cssClass;
                }
            }
            else
            {
                cssClass = "btn-primary";
            }

            cssClass = "btn " + cssClass;

            tb.AddCssClass(cssClass);

            HtmlExtentionsCommon.AddName(tb, name);

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            if (!string.IsNullOrWhiteSpace(glyphicon))
            {
                if (glyphicon.Contains("glyphicon-"))
                {
                    TagBuilder span = new TagBuilder("span");
                    span.AddCssClass(glyphicon);
                    span.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(new { aria_hidden = "true" }));


                    tb.InnerHtml = span.ToString() + " ";
                }
            }
            tb.InnerHtml += innerHtml;

            if (buttonType == null || string.IsNullOrWhiteSpace(buttonType.Value))
            {
                buttonType = HtmlButtonTypes.Submit;
            }

            tb.MergeAttribute("type", buttonType.Value);

            return MvcHtmlString.Create(tb.ToString());

        }

    }
}
