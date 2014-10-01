using Facensa.SegurancaApp.Core.Crypto;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests
{
    [TestClass]
    public class CaesarCipherCryptographerTest
    {
        [TestMethod]
        public void WhenWordIsInsertedThisWordMustBeDifferentThenBefore()
        {
            const string word = "Murilo";

            var caesarChipherEncryptor = new CaesarChipherEncryptor();

            var encryptedResult = caesarChipherEncryptor.Encrypt(word, 3);

            Assert.AreNotEqual(word, encryptedResult);
        }

        [TestMethod]
        public void WhenWordEncryptedThenDecryptShouldBeSameWord()
        {
            const string word = "Murilo";
            const int displacement = 3;

            var caesarChipherEncryptor = new CaesarChipherEncryptor();

            var encryptedResult = caesarChipherEncryptor.Encrypt(word, displacement);
            var decryptedResult = caesarChipherEncryptor.Decrypt(encryptedResult, displacement);

            Assert.IsTrue(word.Equals(decryptedResult));
        }
    }
}