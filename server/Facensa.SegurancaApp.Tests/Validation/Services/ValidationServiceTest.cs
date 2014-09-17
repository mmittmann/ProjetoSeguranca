using Facensa.SegurancaApp.Models;
using Facensa.SegurancaApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Services
{
    [TestClass]
    public class ValidationServiceTest
    {
        private IValidationService _validationService;

        [TestMethod]
        public void WhenWeakWordIsPassedTheResultShouldBeWeak()
        {
            const string word = "teste";

             _validationService = new PasswordValidationService();

            var result = _validationService.MeasurePasswordStrength(word);

            Assert.AreEqual(result, 20);
        }

        [TestMethod]
        public void WhenMediumWordIsPassedTheResultShouldBeMedium()
        {
            const string word = "MeDiUm123";

             _validationService = new PasswordValidationService();

             var result = _validationService.MeasurePasswordStrength(word);

            Assert.AreEqual(result, 50);
        }

        [TestMethod]
        public void WhenStrongWordIsPassedTheResultShouldBeStrong()
        {
            var word = @"@5Tr0ng#4%";

             _validationService = new PasswordValidationService();

             var result = _validationService.MeasurePasswordStrength(word);

             Assert.AreEqual(result, 80);
        }

        [TestMethod]
        public void WhenWordHas3CharsOrLessShouldBeWeak()
        {
            var word = "!A3";

             _validationService = new PasswordValidationService();

             var result = _validationService.MeasurePasswordStrength(word);

            Assert.AreEqual(result, 20);
        }
    }
}
