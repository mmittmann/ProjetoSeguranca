using System;
using Facensa.SegurancaApp.Generate.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Generate.Commands
{
    [TestClass]
    public class UpperCaseGenerateTest
    {
        IGenerateCommand _generateCommand;
        const int UpperCaseAsciiInitValue = 65;
        const int UpperCaseAsciiFinalValue = 90;

        [TestInitialize]
        public void Init()
        {
            _generateCommand = new UpperCaseGenerate();
        }

        [TestMethod]
        public void ShoulbBeGenerateAUpperCase()
        {
            var upperCaseLetter = _generateCommand.Generate();

            Assert.IsTrue((int)upperCaseLetter >= UpperCaseAsciiInitValue && (int)upperCaseLetter <= UpperCaseAsciiFinalValue);
        }
    }
}
