using System;
using Facensa.SegurancaApp.Generate.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Generate.Commands
{
    [TestClass]
    public class SpecialCharGenerateTest
    {
        IGenerateCommand _generateCommand;

        [TestInitialize]
        public void Init()
        {
            _generateCommand = new SpecialCharGenerate();
        }

        [TestMethod]
        public void ShoulbBeGenerateASpecialChar()
        {

        }
    }
}
