using Facensa.SegurancaApp.Models;
using Facensa.SegurancaApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Services
{
    [TestClass]
    public class ValidationServiceTest
    {
        private IValidationService _validationService;

        [TestInitialize]
        public void Init()
        {
            
        }


        [TestMethod]
        public void WhenWeakWordIsPassedTheResultShouldBeWeak()
        {
            var word = "teste";

             _validationService = new PasswordValidationService();

            var result = _validationService.MeasurePasswordStrength(word);

            Assert.IsTrue(result >= 25);
        }

        [TestMethod]
        public void WhenMediumWordIsPassedTheResultShouldBeMedium()
        {
            var word = "MeDiUm123";

             _validationService = new PasswordValidationService();

             var result = _validationService.MeasurePasswordStrength(word);

            Assert.IsTrue(result <= 75 && result >= 25);
        }

        [TestMethod]
        public void WhenStrongWordIsPassedTheResultShouldBeStrong()
        {
            var word = @"@5Tr0ng#4%";

             _validationService = new PasswordValidationService();

             var result = _validationService.MeasurePasswordStrength(word);

             Assert.IsTrue(result >= 75);
        }

        [TestMethod]
        public void WhenWordHas3CharsOrLessIsWeak()
        {
            var word = "!A3";

             _validationService = new PasswordValidationService();

             var result = _validationService.MeasurePasswordStrength(word);

            Assert.IsTrue(result <= 50);
        }
    }
}
