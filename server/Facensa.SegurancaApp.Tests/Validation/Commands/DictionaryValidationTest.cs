using Facensa.SegurancaApp.Commands;
using Facensa.SegurancaApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Commands
{
    [TestClass]
    public class DictionaryValidationTest
    {
        private IValidationCommand _dictionaryValidation;

        [TestInitialize]
        public void Init()
        {
            _dictionaryValidation = new DicionaryValidation();
        }

        [TestMethod]
        public void WhenWordExistsOnDictionaryShouldBeWeak()
        {
            var word = "senhaforte";

            var result = _dictionaryValidation.Validate(word);

            Assert.AreEqual((int)ValidationType.Weak, (int)result);
        }

        [TestMethod]
        public void WhenWordDoesntExistsOnDictionaryShouldBeStrong()
        {
            var word = "estapalavranaocontem";

            var result = _dictionaryValidation.Validate(word);

            Assert.AreEqual((int)ValidationType.Strong, (int)result);
        }
    }
}
