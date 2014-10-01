using System;
using Facensa.SegurancaApp.Core.Crypto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests.Crypto
{
    [TestClass]
    public class DESCryptTest
    {
        private DESEncryptor _desCrypt;

        [TestInitialize]
        public void Init()
        {
            _desCrypt = new DESEncryptor();
        }

        [TestMethod]
        public void WhenCryptAWordItMustBeDifferentBefore()
        {
            var word = "Murilo";

            var encryptedWord = _desCrypt.Encrypt(word);

            Assert.AreNotEqual(word, encryptedWord);
        }

        [TestMethod]
        public void WhenDecryptAWordItMustBeEqualsBefore()
        {
            var word = "Murilo";

            var encryptedWord = _desCrypt.Encrypt(word);
            var decryptedWord = _desCrypt.Decrypt(encryptedWord);

            Assert.AreEqual(word, decryptedWord);
        }
    }
}
