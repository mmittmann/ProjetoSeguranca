using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Facensa.SegurancaApp.Core.Crypto;

namespace Facensa.SegurancaApp.Tests.Crypto
{
    [TestClass]
    public class RSATest
    {
        private RSACrypto rsaCrypto;

        [TestInitialize]
        public void Init()
        {
            rsaCrypto = new RSACrypto(104729, 104723);

        }

        [TestMethod]
        public void WhenICyptWordShouldBeDifferent()
        {
            var word = "teste";

            var encryptedResult = rsaCrypto.Encrypt(word);

            Assert.AreEqual(encryptedResult.Count, 5);
        }

        [TestMethod]
        public void WhenIDecyptWordShouldBeEqual()
        {
            var word = "teste";

            var encryptedResult = rsaCrypto.Encrypt(word);
            var decryptedWord = rsaCrypto.Decrypt(encryptedResult);

            Assert.AreEqual(word, decryptedWord);
        }
    }
}
