using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Commands
{
    [TestClass]
    public class CharContainsValidationTest
    {
        private IValidationCommand _charContainsValidation;

        [TestInitialize]
        public void MyTestMethod()
        {
            _charContainsValidation = new CharContainsValidation();
        }


        [TestMethod]
        public void WhenWeakWordIsPassedTheResultShouldBeWeak()
        {
            var word = "teste";

            var result = _charContainsValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Weak);
        }

        [TestMethod]
        public void WhenMediumWordIsPassedTheResultShouldBeMedium()
        {
            var word = "MeDiUm123";

            var result = _charContainsValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Medium);
        }

        [TestMethod]
        public void WhenStrongWordIsPassedTheResultShouldBeStrong()
        {
            var word = @"@5Tr0ng#4%";

            var result = _charContainsValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Strong);
        }
    }
}
