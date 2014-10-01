using System;
using Facensa.SegurancaApp.Core.Crypto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Crypto
{
    [TestClass]
    public class TripleDesCryptTest
    {
        private TripleDESEncrypt _tripleDesCrypt;

        [TestInitialize]
        public void Init()
        {
            _tripleDesCrypt = new TripleDESEncrypt();
        }

        [TestMethod]
        public void WhenCryptAWordItMustBeDifferentBefore()
        {
            var word = "Murilo";

            var encryptedWord = _tripleDesCrypt.Encrypt(word);

            Assert.AreNotEqual(word, encryptedWord);
        }

        [TestMethod]
        public void WhenDecryptAWordItMustBeEqualsBefore()
        {
            var word = "Murilo";

            var encryptedWord = _tripleDesCrypt.Encrypt(word);
            var decryptedWord = _tripleDesCrypt.Decrypt(encryptedWord);

            Assert.AreEqual(word, decryptedWord);
        }
    }
}
