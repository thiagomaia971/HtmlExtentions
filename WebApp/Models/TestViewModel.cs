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

        public TableList<Usuario> Table { get; set; }

        public string Nome { get; set; }

        public TestViewModel()
        {
            Table = new TableList<Usuario>();

            Table.AddToList(new Usuario() { Id = 1, Login = "asd", Nome = "Fulano", Perfil = new Perfil() { Tipo = "test" } });
            Table.AddToList(new Usuario() { Id = 2, Login = "cxv", Nome = "Tal" });


            Table.AddPropertyToShow(x => x.Login);
            Table.AddPropertyToShow(x => x.Perfil.Tipo);
        }

    }
}
