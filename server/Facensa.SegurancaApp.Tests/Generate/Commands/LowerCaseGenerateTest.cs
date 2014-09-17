using System;
using Facensa.SegurancaApp.Generate.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Generate.Commands
{
    [TestClass]
    public class LowerCaseGenerateTest
    {
        IGenerateCommand _generateCommand;

        [TestInitialize]
        public void Init()
        {
            _generateCommand = new LowerCaseGenerate();
        }

        [TestMethod]
        public void ShoulbBeGenerateALowerCase()
        {

        }
    }
}
