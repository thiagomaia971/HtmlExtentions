using HtmlExtentions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class ImageHtmlExtention
    {

        /// <summary>
        /// Create an Image with src, altText, htmlAttributes.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="src">Image locale in the file i/o.</param>
        /// <param name="altText"></param>
        /// <param name="htmlAttributes">Attributes for the HTML5.</param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src,
            string altText,
            object htmlAttributes = null)
        {
            return ImageHtmlExtention.Image(htmlHelper, src, altText, string.Empty, string.Empty, htmlAttributes);
        }

        /// <summary>
        ///  Create an Image with src, altText, cssClass, htmlAttributes.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="src">Image locale in the file i/o.</param>
        /// <param name="altText"></param>
        /// <param name="cssClass">Class for CSS.</param>
        /// <param name="htmlAttributes">Attributes for the HTML5.</param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            object htmlAttributes = null)
        {
            return ImageHtmlExtention.Image(htmlHelper, src, altText, cssClass, string.Empty, htmlAttributes);
        }

        /// <summary>
        /// Create an Image with src, altText, cssClass, name, htmlAttributes.
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="src">Image locale in the file i/o. </param>
        /// <param name="altText"></param>
        /// <param name="cssClass">Class for CSS.</param>
        /// <param name="name"></param>
        /// <param name="htmlAttributes">Attributes for the HTML5.</param>
        /// <returns></returns>
        public static MvcHtmlString Image(this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            string name,
            object htmlAttributes = null)
        {

            TagBuilder tb = new TagBuilder("img");

            HtmlExtentionsCommon.AddName(tb, name);

            tb.MergeAttribute("src", src);
            tb.MergeAttribute("alt", altText);

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        }

    }
}
