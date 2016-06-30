using Core;
using HtmlExtentions.Entities;
using HtmlExtentions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class TestViewModel
    {

        public ITableList<Usuario> Table { get; set; }

        public TestViewModel()
        {
            Table = new TableList<Usuario>();

            Table.AddToList(new Usuario() { Id = 1, Login = "asd", Nome = "Fulano"});
            Table.AddToList(new Usuario() { Id = 2, Login = "cxv", Nome = "Tal" });

            Table.AddPropertyToShow(x => x.Nome);
        }

    }
}
