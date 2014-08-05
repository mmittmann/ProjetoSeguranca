using System;
using Facensa.SegurancaApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Services
{
    [TestClass]
    public class ValidationServiceTest
    {
        [TestMethod]
        public void WhenWeakWordIsPassedTheResultShouldBeWeak()
        {
            var word = "teste";

            var vs = new PasswordValidationService();

            var result = vs.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Weak);
        }

        [TestMethod]
        public void WhenMediumWordIsPassedTheResultShouldBeMedium()
        {
            var word = "MeDiUm123";

            var vs = new PasswordValidationService();

            var result = vs.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Medium);
        }

        [TestMethod]
        public void WhenStrongWordIsPassedTheResultShouldBeStrong()
        {
            var word = @"@5Tr0ng#4%";

            var vs = new PasswordValidationService();

            var result = vs.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Strong);
        }
    }
}
