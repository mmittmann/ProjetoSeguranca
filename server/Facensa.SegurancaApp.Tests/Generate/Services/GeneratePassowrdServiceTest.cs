using System;
using Facensa.SegurancaApp.Generate.Service;
using Facensa.SegurancaApp.Models;
using Facensa.SegurancaApp.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Generate.Services
{
    [TestClass]
    public class GeneratePassowrdServiceTest
    {
        private PasswordGenerateService _passwordGenerator;
        private PasswordValidationService _passwordValidationService;


        [TestInitialize]
        public void Init()
        {
            _passwordGenerator = new PasswordGenerateService();
            _passwordValidationService = new PasswordValidationService();
        }

        [TestMethod]
        public void WhenAWeakPasswordIsRequestedAWeakPasswordShouldBeCreated()
        {
            var passwordGenerated = _passwordGenerator.Generate(4, ValidationType.Weak);

            Assert.AreEqual(_passwordValidationService.MeasurePasswordStrength(passwordGenerated), 20);
        }

        [TestMethod]
        public void WhenAStrongPasswordIsRequestedAStrongPasswordShouldBeCreated()
        {
            var passwordGenerated = _passwordGenerator.Generate(8, ValidationType.Strong);

            Assert.AreEqual(_passwordValidationService.MeasurePasswordStrength(passwordGenerated), 100);
        }

        [TestMethod]
        public void WhenAMediumPasswordIsRequestedAMediumPasswordShouldBeCreated()
        {
            var passwordGenerated = _passwordGenerator.Generate(6, ValidationType.Medium);

            Assert.AreEqual(_passwordValidationService.MeasurePasswordStrength(passwordGenerated), 50);
        }
    }
}
