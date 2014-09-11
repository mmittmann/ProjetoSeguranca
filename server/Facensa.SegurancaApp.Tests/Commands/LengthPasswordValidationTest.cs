using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Commands
{
    [TestClass]
    public class LengthPasswordValidationTest
    {
        private IValidationCommand _lenghtValidation;

        [TestInitialize]
        public void MyTestMethod()
        {
            _lenghtValidation = new LengthPasswordValidation();
        }

        [TestMethod]
        public void WhenWordHas3CharsOrLessShouldBeWeak()
        {
            var word = "#4s";

            var result = _lenghtValidation.Validate(word);

            Assert.AreEqual((int)ValidationType.Weak, (int)result);
        }

        [TestMethod]
        public void WhenWordHasBetween4And8CharsShouldBeMedium()
        {
            var word = "S&i566";

            var result = _lenghtValidation.Validate(word);

            Assert.AreEqual((int)ValidationType.Medium, (int)result);
        }
    }
}
