using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlExtentions.Interfaces;
using Core;
using HtmlExtentions.Entities;
using System.Web.Mvc;

namespace Testes
{
    [TestClass]
    public class When_A_TableListFor
    {
        [TestMethod]
        public void TestMethod1()
        {

            ITableList<Usuario> table = new TableList<Usuario>();

            table.AddToList(new Usuario() { Id = 1, Login = "as", Nome = "test"});
            table.AddToList(new Usuario() { Id = 2, Login = "ba", Nome = "tebg" });

            table.AddPropertyToShow(x => x.Nome);


        }
    }
}
