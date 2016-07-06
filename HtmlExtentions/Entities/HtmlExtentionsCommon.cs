using System;
using System.Web;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

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


        public static string GetDisplayName<TEntity, TProperty>(this TEntity src, Expression<Func<TEntity, TProperty>> exp)
        {
            MemberExpression memberExp = exp.Body as MemberExpression;

            if (memberExp == null)
            {
                throw new ArgumentException("Must be a MemeberExpression", "exp");
            }

            var attr = memberExp.Member
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .SingleOrDefault();

            return (attr != null) ? attr.Name : memberExp.Member.Name;

        }

        public static string GetDisplayName<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> exp)
        {
            MemberExpression memberExp = exp.Body as MemberExpression;

            if (memberExp == null)
            {
                throw new ArgumentException("Must be a MemeberExpression", "exp");
            }

            var attr = memberExp.Member
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .SingleOrDefault();

            return (attr != null) ? attr.Name : memberExp.Member.Name;

        }

        public static string GetDisplayName<T>(this T src, IEnumerable<CustomAttributeData> CustomAttributes)
        {
            return CustomAttributeData.GetCustomAttributes(typeof(DisplayAttribute)).ToString();
        }

        //public static string GetValue<T>(T item, PropertyInfo Property)
        //{

        //    object value = null;

        //    foreach (var prop in item.GetType().GetProperties())
        //    {

        //        if (prop.PropertyType.GetProperties().Count() > 0)
        //        {



        //        }

        //    }

        //}

        public static string GetPropertyName<T, P>(Expression<Func<T,P>> exp ) where T : class
        {
            var member = exp.Body as MemberExpression;

            if (member == null)
            {
                UnaryExpression unary = (UnaryExpression)exp.Body;
                member = unary.Operand as MemberExpression;
            }

            return member.Member.Name;
        }

        public static string GetFullName<T>(this T src, PropertyInfo property) where T: class
        {

            var member = property.PropertyType.FullName;

            
            if (member.Split('.').Count() > 0)
            {

                member = typeof(T).GetFullName(typeof(T).GetProperty(member.Split('.')[0]));


            }
            return member;

        }

        public static Expression<Func<TInput, object>> ConvertExpressionToObjectOutput<TInput, TOutput>(Expression<Func<TInput, TOutput>> expression) where TOutput : Attribute
        {

            Expression converted = Expression.Convert(expression.Body, typeof(object));

            return Expression.Lambda<Func<TInput, object>>(converted, expression.Parameters);

        }

        public static Expression<Func<TInput, TOutput>> ConvertExpressionToTOutput<TInput, TOutput>(Expression<Func<TInput, object>> expression)
        {

            Expression converted = Expression.Convert(expression.Body, typeof(TOutput));

            return Expression.Lambda<Func<TInput, TOutput>>(converted, expression.Parameters);

        }

        public static PropertyToShow ShowThisProperty<TEntity>(PropertyInfo Property, ICollection<PropertyToShow> PropertiesToShow, TEntity entity) where TEntity : class
        {

            PropertyToShow isShow = null;

            if (Property.PropertyType.GetProperties().Count() > 0)
            {

                foreach (PropertyInfo p in Property.PropertyType.GetProperties())
                {

                    if (PropertiesToShow.Where(pt => pt.PropertyName == p.Name).FirstOrDefault() != null)
                    {

                        isShow = PropertiesToShow.Where(pt => pt.PropertyName == p.Name).FirstOrDefault();

                        if (isShow != null)
                        {


                            isShow.Value = entity.GetType().GetProperty(isShow.PropertyName).GetValue(entity);

                        }

                    }

                }

                if (isShow == null)
                {
                    isShow = PropertiesToShow.Where(pt => pt.PropertyName == Property.Name).FirstOrDefault();
                    if (isShow != null)
                    {


                        isShow.Value = entity.GetType().GetProperty(isShow.PropertyName).GetValue(entity);

                    }
                }

            }
            else
            {
                isShow = PropertiesToShow.Where(pt => pt.PropertyName == Property.Name).FirstOrDefault();

                if (isShow != null)
                {
                

                    isShow.Value = entity.GetType().GetProperty(isShow.PropertyName).GetValue(entity);

                }
            }


            return isShow;

        }


    }
}
