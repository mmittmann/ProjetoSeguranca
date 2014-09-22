using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Facensa.SegurancaApp.Tests
{
    [TestClass]
    public class CaesarCipherCryptographer
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

    public class CaesarChipherEncryptor
    {
        public string Encrypt(string word, int displacement)
        {
            var encryptedWord = new List<char>();
            foreach (var letter in word)
            {
                var charNumber = letter - displacement;
                encryptedWord.Add((char)charNumber);
            }

            return new String(encryptedWord.ToArray());
        }

        public string Decrypt(string word, int displacement)
        {
            var encryptedWord = new List<char>();
            foreach (var letter in word)
            {
                var charNumber = letter + displacement;
                encryptedWord.Add((char)charNumber);
            }

            return new String(encryptedWord.ToArray());
        }
    }
}
