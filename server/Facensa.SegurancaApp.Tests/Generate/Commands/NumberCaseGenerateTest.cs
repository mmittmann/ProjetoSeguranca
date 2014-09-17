using System;
using Facensa.SegurancaApp.Generate.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Generate.Commands
{
    [TestClass]
    public class NumberCaseGenerateTest
    {
        IGenerateCommand _generateCommand;

        [TestInitialize]
        public void Init()
        {
            _generateCommand = new NumberGenerate();
        }

        [TestMethod]
        public void ShoulbBeGenerateANumber()
        {
            int parseTest = 0;
            var result = _generateCommand.Generate();

            Assert.IsTrue((int)result >= 48 && (int)result <= 57);
            Assert.IsTrue(int.TryParse(result.ToString(), out parseTest));
        }
    }
}
