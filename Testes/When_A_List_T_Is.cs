using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HtmlExtentions.Interfaces;
using Core;
using System.Collections.Generic;

namespace Testes
{
    [TestClass]
    public class When_A_List_T_Is
    {

        Mock<ITableList<Usuario>> mockTableList;
        ITableList<Usuario> tableList;

        public When_A_List_T_Is()
        {

            mockTableList = new Mock<ITableList<Usuario>>();
            tableList = mockTableList.Object;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Added_A_UsuarioIsNull_ThrowsArgumentNullException()
        {

            // Arrange

            Usuario usuario = null;

            mockTableList.Setup(u => u.List).Returns(new List<Usuario>());
            mockTableList.Setup(u => u.AddToList(usuario)).Throws<ArgumentNullException>();

            // Act

            tableList.AddToList(usuario);

            // Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Added_A_IColletionUsuarioIsNull_ThrowsNullReferenceException()
        {

            //Arrange

            List<Usuario> usuarios = null;

            mockTableList.Setup(mTableList => mTableList.List).Returns(new List<Usuario>());
            mockTableList.Setup(mTableList => mTableList.AddToList(usuarios)).Throws<ArgumentNullException>();

            //Act

            tableList.AddToList(usuarios);

            //Assert

        }

        [TestMethod]
        public void Added_A_Usuario_ListCountOneMore()
        {

            // Arrange

            Usuario usuario = new Usuario()
            {
                Id = 1,
                Login = "dragus12",
                Nome = "Thiago Maia"
            };

            mockTableList.Setup(mTableList => mTableList.List).Returns(new List<Usuario>() { usuario });
            mockTableList.Setup(mTableList => mTableList.AddToList(usuario));

            // Act

            tableList.AddToList(usuario);

            //Assert

            mockTableList.Verify(mTableList => mTableList.AddToList(usuario), Times.Exactly(1));

            mockTableList.Verify();

        }

    }
}
