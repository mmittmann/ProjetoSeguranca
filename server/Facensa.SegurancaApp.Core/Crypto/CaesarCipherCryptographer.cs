using System;
using System.Collections.Generic;

namespace Facensa.SegurancaApp.Core.Crypto
{
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
