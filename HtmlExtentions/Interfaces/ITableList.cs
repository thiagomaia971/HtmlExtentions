using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace HtmlExtentions.Interfaces
{
    public interface ITableList<TEntity>
    {

        /// <summary>
        /// List to Show.
        /// </summary>
        ICollection<TEntity> List { get; }

        /// <summary>
        /// Properties to Show.
        /// </summary>
        ICollection<PropertyToShow> PropertiesToShow { get; }

        /// <summary>
        /// Adding a Element to the List.
        /// </summary>
        /// <param name="Element">T Entity.</param>
        void AddToList(TEntity Entity);

        /// <summary>
        /// Adding a IColletion of T to the List.
        /// </summary>
        /// <param name="Entities">IColletion of T</param>
        void AddToList(ICollection<TEntity> Entities);

        /// <summary>
        /// Adding a Property from T to the PropertiesToShow.
        /// </summary>
        /// <param name="property">A Func to the Property.</param>
        void AddPropertyToShow<TProperty>(Expression<Func<TEntity, TProperty>> Property);

    }
}
