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
            Html5InputTypes type = Html5InputTypes.Text,
            bool required = false,
            string icon = null,
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

            if (!string.IsNullOrEmpty(icon))
            {

                TagBuilder div = new TagBuilder("div");
                div.AddCssClass("icon-div");

                TagBuilder iconTb = new TagBuilder("i");
                iconTb.AddCssClass("icon-input");
                iconTb.AddCssClass(icon);

                div.InnerHtml = iconTb.ToString();

                formGroup.InnerHtml += div.ToString();

            }


            formGroup.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            string htmlFieldName = ExpressionHelper.GetExpressionText(expression);
            string labelText = metadata.DisplayName ?? metadata.PropertyName ?? htmlFieldName.Split('.').Last();

            formGroup.InnerHtml += TextBoxHtmlExtention.TextBoxFor(htmlHelper, expression, labelText, string.Empty, autofocus, required, type);
            formGroup.InnerHtml += LabelForHtmlExtention.LabelFor(htmlHelper, expression);
            formGroup.InnerHtml += ValidationExtensions.ValidationMessageFor(htmlHelper, expression);

            return MvcHtmlString.Create(formGroup.ToString());

        }

    }
}
