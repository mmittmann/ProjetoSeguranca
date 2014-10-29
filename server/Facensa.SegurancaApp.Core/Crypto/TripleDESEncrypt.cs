using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Facensa.SegurancaApp.Core.Crypto
{
    public class TripleDESEncrypt
    {
        private static  byte[] bytes = Encoding.ASCII.GetBytes("#78?U????-\b#??)r??????a");

        public TripleDESEncrypt()
        {
            
        }

        public TripleDESEncrypt(string key)
        {
            bytes = Encoding.ASCII.GetBytes(key);
        }

        public string Encrypt(string input)
        {
            var inputArray = Encoding.UTF8.GetBytes(input);
            var tripleDES = new TripleDESCryptoServiceProvider();
        

            tripleDES.Key = bytes;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
   
            var cTransform = tripleDES.CreateEncryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public string Decrypt(string input)
        {
            var inputArray = Convert.FromBase64String(input);

            var tripleDES = new TripleDESCryptoServiceProvider();
       

            tripleDES.Key = bytes;
            tripleDES.Mode = CipherMode.ECB;
            tripleDES.Padding = PaddingMode.PKCS7;
  
            
            
            var cTransform = tripleDES.CreateDecryptor();
            var resultArray = cTransform.TransformFinalBlock(inputArray, 0, inputArray.Length);
            tripleDES.Clear();
            return Encoding.UTF8.GetString(resultArray);
        }
    }
}
