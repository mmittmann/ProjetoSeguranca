using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Commands
{
    [TestClass]
    public class DateValidationTest
    {
        private DateValidation _dateValidation;

        [TestInitialize]
        public void Init()
        {
            _dateValidation = new DateValidation();
        }

        [TestMethod]
        public void WhenHasDateInStartOfWordIsWeak()
        {
            var word = "251190murilo";

            var result = _dateValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Weak);
        }

        [TestMethod]
        public void WhenHasDateInHalfOfWordIsWeak()
        {
            var word = "muri251190lo";

            var result = _dateValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Weak);
        }

        [TestMethod]
        public void WhenHasDateInEndOfWordIsWeak()
        {
            var word = "murilo251190";

            var result = _dateValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Weak);
        }

        [TestMethod]
        public void WhenHasDateWith8CharsWordIsWeak()
        {
            var word = "mm25111990";

            var result = _dateValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Weak);
        }

        [TestMethod]
        public void WhenHasNotDateNumbersWordIsStrong()
        {
            var word = "12345678";

            var result = _dateValidation.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Strong);
        }
    }
}
