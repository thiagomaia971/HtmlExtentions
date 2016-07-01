using HtmlExtentions.Entities;
using HtmlExtentions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    public static class TableListForHtmlExtention
    {

        /// <summary>
        /// Create a Table Layout.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlhelper"></param>
        /// <param name="viewModel">Model with List to Show and Properties to Show.</param>
        /// <param name="htmlAttributes"></param>

        /// <returns></returns>
        public static MvcHtmlString TableListFor<T>(this HtmlHelper htmlhelper,
            ITableList<T> viewModel,
            object htmlAttributes = null) where T : class
        {

            return TableListForHtmlExtention.TableListFor(htmlhelper, viewModel, false, false, false, htmlAttributes);

        }

        /// <summary>
        /// Create a Table Layout.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlhelper"></param>
        /// <param name="viewModel">Model with List to Show and Properties to Show.</param>
        /// <param name="withEdit">A boolean type for create a Table with Edit button</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString TableListFor<T>(this HtmlHelper htmlhelper,
            ITableList<T> viewModel,
            bool withEdit = false,
            object htmlAttributes = null) where T : class
        {

            return TableListForHtmlExtention.TableListFor(htmlhelper, viewModel, withEdit, false, false, htmlAttributes);

        }

        /// <summary>
        /// Create a Table Layout.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlhelper"></param>
        /// <param name="viewModel">Model with List to Show and Properties to Show.</param>
        /// <param name="withEdit">A boolean type for create a Table with Edit button</param>
        /// <param name="withRemove">A boolean type for create a Table with Remove button</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString TableListFor<T>(this HtmlHelper htmlhelper,
            ITableList<T> viewModel,
            bool withEdit = false,
            bool withRemove = false,
            object htmlAttributes = null) where T : class
        {

            return TableListForHtmlExtention.TableListFor(htmlhelper, viewModel, withEdit, withRemove, false, htmlAttributes);

        }

        /// <summary>
        /// Create a Table Layout.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="htmlhelper"></param>
        /// <param name="viewModel">Model with List to Show and Properties to Show.</param>
        /// <param name="withEdit">A boolean type for create a Table with Edit button</param>
        /// <param name="withRemove">A boolean type for create a Table with Remove button</param>
        /// <param name="withDetail">A boolean type for create a Table with Detail button</param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static MvcHtmlString TableListFor<T>(this HtmlHelper htmlhelper,
            ITableList<T> viewModel,
            bool withEdit = false,
            bool withRemove = false,
            bool withDetail = false,
            object htmlAttributes = null) where T : class
        {

            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("table table-bordered table-hover table-responsive");

            TagBuilder tr = new TagBuilder("tr");

            List<string> Properties = new List<string>();

            foreach (var propertyToShow in viewModel.PropertiesToShow)
            {

                var action = propertyToShow.Body as MemberExpression;
                var unary = propertyToShow.Body as UnaryExpression;

                string nameOfProperty = (action == null ? (unary == null ? null : (unary.Operand as MemberExpression).Member.Name) : action.Member.Name);
                Properties.Add(nameOfProperty);

                TagBuilder th = new TagBuilder("th");

                th.MergeAttribute("style", "cursor: default; ");

                th.InnerHtml = nameOfProperty;

                tr.InnerHtml += th.ToString();
            }

            if (withEdit)
            {
                tr.InnerHtml += HtmlExtentionsCommon.CreateTagBuilder("th", "Editar", new { style = "width: 5%; cursor: default;" }).ToString();
            }

            if (withDetail)
            {
                tr.InnerHtml += HtmlExtentionsCommon.CreateTagBuilder("th", "Detalhes", new { style = "width: 5%; cursor: default" }).ToString();
            }

            if (withRemove)
            {
                tr.InnerHtml += HtmlExtentionsCommon.CreateTagBuilder("th", "Remover", new { style = "width: 5%; cursor: default" }).ToString();
            }

            TagBuilder tHead = HtmlExtentionsCommon.CreateTagBuilder("thead", tr.ToString());


            TagBuilder tbody = new TagBuilder("tbody");

            foreach (var item in viewModel.List)
            {
                TagBuilder trItem = new TagBuilder("tr");
                var propertiesFromTheItem = item.GetType().GetProperties();

                foreach (var property in propertiesFromTheItem)
                {

                    var s = Properties.Where(toShow => toShow == property.Name).FirstOrDefault();

                    if (s != null)
                    {
                        TagBuilder td = new TagBuilder("td");
                        td.InnerHtml = item.GetType().GetProperty(property.Name).GetValue(item).ToString();
                        td.MergeAttribute("style", "padding-top: 15px");
                        trItem.InnerHtml += td.ToString();
                    }
                }

                if (withEdit)
                {
                    var button = HtmlExtentionsCommon.CreateTagBuilder("td",
                        ButtonHtmlExtention.Button(
                            htmlhelper, string.Empty,
                            "btn-info col-lg-12", string.Empty,
                            "glyphicon glyphicon-edit",
                            HtmlButtonTypes.Button,
                            new { data_action = "editar", data_actionId = item.GetType().GetProperty("Id").GetValue(item).ToString(), title = "Editar" }
                        ).ToString());

                    trItem.InnerHtml += button.ToString();
                }

                if (withDetail)
                {

                    var button = HtmlExtentionsCommon.CreateTagBuilder("td",
                        ButtonHtmlExtention.Button(
                            htmlhelper, string.Empty,
                            "btn-success col-lg-8 col-lg-offset-2", string.Empty,
                            "glyphicon glyphicon-search",
                            HtmlButtonTypes.Button,
                            new { data_action = "editar", data_actionId = item.GetType().GetProperty("Id").GetValue(item).ToString(), title = "Detalhe" }
                        ).ToString());
                    trItem.InnerHtml += button.ToString();

                }

                if (withRemove)
                {

                    var button = HtmlExtentionsCommon.CreateTagBuilder("td",
                        ButtonHtmlExtention.Button(
                            htmlhelper, string.Empty,
                            "btn-danger col-lg-8 col-lg-offset-2", string.Empty,
                            "glyphicon glyphicon-trash",
                            HtmlButtonTypes.Button,
                            new { data_action = "remover", data_actionId = item.GetType().GetProperty("Id").GetValue(item).ToString(), title = "Remover" }
                        ).ToString());
                    trItem.InnerHtml += button.ToString();

                }

                tbody.InnerHtml += trItem.ToString();

            }
            table.InnerHtml = tHead.ToString();
            table.InnerHtml += tbody.ToString();

            if (htmlAttributes != null)
            {

                var anonymousObject = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

                if (anonymousObject.Select(x => x.Value.ToString().Contains("margin")).FirstOrDefault())
                {

                    table.MergeAttributes(anonymousObject);

                }
                else
                {

                    anonymousObject.Add("style", "margin: 10px 0px");

                }

            }
            else if (htmlAttributes != null)
            {
                table.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(new { style = "margin: 10px 0px; form-group" }));

            }

            return MvcHtmlString.Create(table.ToString());
        }

    }
}
