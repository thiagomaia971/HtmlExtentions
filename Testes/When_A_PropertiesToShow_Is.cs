using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using HtmlExtentions.Interfaces;
using Moq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Testes
{
    [TestClass]
    public class When_A_PropertiesToShow_Is
    {

        Mock<ITableList<Usuario>> mockTableList;
        ITableList<Usuario> tableList;

        public When_A_PropertiesToShow_Is()
        {

            mockTableList = new Mock<ITableList<Usuario>>();
            tableList = mockTableList.Object;

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Added_A_PropertyToShowIsNull_ThrowsArgumentNullException()
        {

            // Arrange

            Expression<Func<Usuario, object>> property = null;

            mockTableList.Setup(u => u.List).Returns(new List<Usuario>());
            mockTableList.Setup(u => u.AddPropertyToShow(property)).Throws<ArgumentNullException>();

            // Act

            tableList.AddPropertyToShow(property);

            // Assert

        }

    }
}
