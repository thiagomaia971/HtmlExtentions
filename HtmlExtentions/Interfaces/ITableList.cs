using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HtmlExtentions.Interfaces
{
    public interface ITableList<T>
    {

        /// <summary>
        /// List to Show.
        /// </summary>
        ICollection<T> List { get; }

        /// <summary>
        /// Properties to Show.
        /// </summary>
        ICollection<Expression<Func<T, object>>> PropertiesToShow { get; }

        /// <summary>
        /// Adding a Element to the List.
        /// </summary>
        /// <param name="Element">T Entity.</param>
        void AddToList(T Entity);

        /// <summary>
        /// Adding a IColletion of T to the List.
        /// </summary>
        /// <param name="Entities">IColletion of T</param>
        void AddToList(ICollection<T> Entities);

        /// <summary>
        /// Adding a Property from T to the PropertiesToShow.
        /// </summary>
        /// <param name="property">A Func to the Property.</param>
        void AddPropertyToShow(Expression<Func<T, object>> property);

    }
}
