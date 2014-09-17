using System;
using Facensa.SegurancaApp.Services;
using Facensa.SegurancaApp.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests
{
    [TestClass]
    public class DateUtilServiceTest
    {
        DateUtilService _dateUtilService;

        [TestInitialize]
        public void Init()
        {
            _dateUtilService = new DateUtilService();                
        }

        [TestMethod]
        public void WhenPassAStringDateCanConvertToDate()
        {
            const string stringToConvert = "251190";

            var canConvertToDate = _dateUtilService.CanConvertToDate(stringToConvert);

            Assert.IsTrue(canConvertToDate);
        }

        [TestMethod]
        public void WhenPassANotStringDateCantConvertToDate()
        {
            const string stringToConvert = "12345678";

            var canConvertToDate = _dateUtilService.CanConvertToDate(stringToConvert);

            Assert.IsFalse(canConvertToDate);
        }
    }
}
