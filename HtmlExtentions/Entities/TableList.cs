using Core;
using HtmlExtentions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HtmlExtentions.Entities
{
    public class TableList<TEntity> : ITableList<TEntity> where TEntity : class
    {

        public ICollection<TEntity> List { get; private set; }

        public ICollection<PropertyToShow> PropertiesToShow { get; private set;  }


        public TableList()
        {

            List = new List<TEntity>();
            PropertiesToShow = new List<PropertyToShow>();

        }


        public void AddToList(TEntity Entity)
        {

            if (Entity == null)
            {
                throw new ArgumentNullException("Entity", "The Entity Paramater don't be null.");
            }

            List.Add(Entity);
        }

        public void AddToList(ICollection<TEntity> Entities)
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

        public void AddPropertyToShow<TProperty>(Expression<Func<TEntity, TProperty>> Property) 
        {
            if (Property == null)
            {
                throw new ArgumentNullException("Property", "The property Paramater don't be null.");
            }

            PropertiesToShow.Add(
                new PropertyToShow()
                {
                    PropertyName = HtmlExtentionsCommon.GetPropertyName(Property),
                    DisplayProperty = HtmlExtentionsCommon.GetDisplayName(Property)
                    
                }
            );

        }

    }
}
