using System;
using Facensa.SegurancaApp.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Controllers
{
    [TestClass]
    public class ValidationControllerTest
    {
        [TestMethod]
        public void WhenWordIsPassedByGetResultShouldBeNotNull()
        {
            var word = "teste";

            var ctrl = new ValidationController();

            var result = ctrl.Get(word);

            Assert.IsNotNull(result);
        }


    }
}
