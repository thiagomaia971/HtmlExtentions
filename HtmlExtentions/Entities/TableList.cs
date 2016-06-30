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

        public ICollection<T> List { get; private set; }

        public ICollection<Expression<Func<T, object>>> PropertiesToShow { get; private set;  }

        public TableList()
        {

            List = new List<T>();
            PropertiesToShow = new List<Expression<Func<T, object>>>();

        }


        public void AddToList(T Entity)
        {

            if (Entity == null)
            {
                throw new ArgumentNullException("Entity", "The Entity Paramater don't be null.");
            }

            List.Add(Entity);
        }

        public void AddToList(ICollection<T> Entities)
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

        public void AddPropertyToShow(Expression<Func<T, object>> property)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property", "The property Paramater don't be null.");
            }

            PropertiesToShow.Add(property);

        }

    }
}
