using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography;

namespace Facensa.SegurancaApp.Core.Crypto
{
    public class RSACrypto
    {
        private uint p, q;
        private static KeyValuePair<uint, uint> publicKey, privateKey;

        public RSACrypto()
        {
            p = Prime.GetRandom();
            q = Prime.GetRandom();

            Init();
        }

        public RSACrypto(uint pKey, uint qKey)
        {
            this.p = pKey;
            this.q = qKey;

            Init();
        }

        public KeyValuePair<uint, uint> GetPublicKey()
        {
            return publicKey;
        }

        public List<uint> Encrypt(string word)
        {
            List<uint> cypherNumbers = new List<uint>();
            foreach (var w in word)
            {
                int letterAsciiNumber = (int)w;
                var pow = BigInteger.Pow(new BigInteger(letterAsciiNumber), (int)publicKey.Value);
                cypherNumbers.Add((uint)(pow % publicKey.Key));
            }

            return cypherNumbers;
        }

        public List<uint> Encrypt(string word, KeyValuePair<uint, uint> mePublicKey)
        {
            List<uint> cypherNumbers = new List<uint>();
            foreach (var w in word)
            {
                int letterAsciiNumber = (int)w;
                var pow = BigInteger.Pow(new BigInteger(letterAsciiNumber), (int)mePublicKey.Value);
                cypherNumbers.Add((uint)(pow % mePublicKey.Key));
            }

            return cypherNumbers;
        }

        public string Decrypt(List<uint> numbers)
        {
            var decryptedWord = "";
            foreach (var n in numbers)
            {
                var pow = BigInteger.Pow(new BigInteger(n), (int)privateKey.Value);
                decryptedWord += ((char)(pow % privateKey.Key));
            }

            return decryptedWord;
        }


        private void Init()
        {
            var n = GetN();
            var z = Totiente();
            var e = GetE(z);
            var d = GetD(e, z);

            publicKey = new KeyValuePair<uint, uint>(n, e);
            privateKey = new KeyValuePair<uint, uint>(n, d);
        }

        private uint GetD(uint e, uint z)
        {

            int d;

            for (d = 1; d <= z; d++)
            {
                if ((e * d) % z == 1)
                    return (uint)d;

            }
            return 0;
        }

        private uint EuclidesAlgoritim(uint e, uint z)
        {

            uint r = 0;

            while (r != 1)
            {
                r = e % z;
                e = z;
                z = r;
            }

            return 1;
        }

        private uint GetN()
        {
            return (uint)(p * q);
        }

        private uint Totiente()
        {
            return (uint)((p - 1) * (q - 1));
        }

        private uint GetE(uint v)
        {
            for (uint i = v - 1; i > 0; i--)
            {
                if (Prime.IsCoPrime(v, i))
                    return i;
            }

            return 0;
        }
    }


}
