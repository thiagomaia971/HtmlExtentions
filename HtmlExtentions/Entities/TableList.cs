using HtmlExtentions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HtmlExtentions.Entities
{
    public class TableList<T> : ITableList<T>
    {

        public ICollection<T> List { get { return List; } private set { } }

        public ICollection<Expression<Func<T, object>>> PropertiesToShow { get { return PropertiesToShow; } private set { } }

        public TableList()
        {

            List = new List<T>();
            PropertiesToShow = new List<Expression<Func<T, object>>>();

        }


        void ITableList<T>.AddToList(T Entity)
        {

            if (Entity == null)
            {
                throw new ArgumentNullException("Entity", "The Entity Paramater don't be null.");
            }

            List.Add(Entity);
        }

        void ITableList<T>.AddToList(ICollection<T> Entities)
        {

            if (Entities == null)
            {
                throw new ArgumentNullException("Entities", "The Entities Paramater don't be null.");
            }

            foreach (var item in Entities)
            {
                List.Add(item);
            }

        }

        void ITableList<T>.AddPropertyToShow(Expression<Func<T, object>> property)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property", "The property Paramater don't be null.");
            }

            PropertiesToShow.Add(property);

        }

    }
}
