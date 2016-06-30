using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlExtentions.Entities
{
    public static class HtmlExtentionsCommon
    {

        public static void AddName(TagBuilder tb,
            string name, string id = null)
        {

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = TagBuilder.CreateSanitizedId(name);

                if (string.IsNullOrWhiteSpace(id))
                {
                    tb.GenerateId(name);
                }
                else
                {
                    tb.MergeAttribute("id", TagBuilder.CreateSanitizedId(id));
                }

                tb.MergeAttribute("name", name);
            }

        }

        public static TagBuilder CreateTagBuilder(string tag, string innerHtml, object htmlAttributes = null)
        {

            TagBuilder tagBuilder = new TagBuilder(tag);

            tagBuilder.InnerHtml = innerHtml;


            if (htmlAttributes != null)
            {

                tagBuilder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            }

            return tagBuilder;

        }

        public static TagBuilder CreateTagBuilder(string tag)
        {
            return new TagBuilder(tag);
        }

    }
}
