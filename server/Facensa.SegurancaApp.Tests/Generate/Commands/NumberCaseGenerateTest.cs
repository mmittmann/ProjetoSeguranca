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

        }
    }
}
