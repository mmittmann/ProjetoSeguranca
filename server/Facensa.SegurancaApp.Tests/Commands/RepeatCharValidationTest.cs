using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Commands
{
    [TestClass]
    public class RepeatCharValidationTest
    {
        private RepeatCharValidation _repeatCharTest;

        [TestInitialize]
        public void Init()
        {
            _repeatCharTest = new RepeatCharValidation();
        }

        [TestMethod]
        public void WhenHas3RepeatedCharsShouldBeWeak()
        {
            var word = "teeeste";

            var result = _repeatCharTest.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Weak);
        }

        [TestMethod]
        public void WhenHas2RepeatedCharsShouldBeWeak()
        {
            var word = "teeste";

            var result = _repeatCharTest.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Medium);
        }

        [TestMethod]
        public void WhenHasNoRepeatedCharsShouldBeWeak()
        {
            var word = "teste";

            var result = _repeatCharTest.Validate(word);

            Assert.AreEqual((int)result, (int)ValidationType.Strong);
        }
    }
}
