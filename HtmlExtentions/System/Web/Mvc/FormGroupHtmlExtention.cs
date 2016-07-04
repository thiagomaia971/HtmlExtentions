using HtmlExtentions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace System.Web.Mvc
{
    public static class FormGroupHtmlExtention
    {

        public static MvcHtmlString FormGroupFor<TModel, TValue>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TValue>> expression,
            bool autofocus = false,
            string cssClass = null,
            object htmlAttributes = null
            )
        {

            TagBuilder formGroup = new TagBuilder("div");

            if (!string.IsNullOrWhiteSpace(cssClass))
            {

                if (cssClass.Contains("form-group"))
                {
                    formGroup.AddCssClass(cssClass);
                }
                else
                {
                    formGroup.AddCssClass("form-group " + cssClass);
                }

            }

            formGroup.AddCssClass("form-group");

            formGroup.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            formGroup.InnerHtml += LabelForHtmlExtention.LabelFor(htmlHelper, expression);
            formGroup.InnerHtml += TextBoxHtmlExtention.TextBoxFor(htmlHelper, expression, labelText, labelText, autofocus);
            formGroup.InnerHtml += ValidationExtensions.ValidationMessageFor(htmlHelper, expression);

            return MvcHtmlString.Create(formGroup.ToString());

        }

    }
}
