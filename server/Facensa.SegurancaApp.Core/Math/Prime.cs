using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facensa.SegurancaApp.Core.Crypto
{
    public static class Prime
    {
        public static bool IsPrime(int number)
        {
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            if (number == 1) return false;
            if (number == 2) return true;

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        public static uint GetRandom()
        {
            //List<uint> primes = new List<uint>(){
            //    10007,
            //    10009,
            //    10037,
            //    10039,
            //    10061,
            //    10067,
            //    10069,
            //    10079,
            //    10091,
            //    10093,
            //    10099
            //};

            List<uint> primes = new List<uint>(){
                7,
                5,
                11,
                13,
                17
            };

            return primes[new Random().Next(primes.Count - 1)];
        }

        public static bool IsCoPrime(uint v1, uint v2)
        {
            return FindGCDModulus(v1, v2) == 1;
        }

        private static uint FindGCDModulus(uint value1, uint value2)
{
        while(value1 != 0 && value2 != 0)
        {
                if (value1 > value2)
                {
                        value1 %= value2;
                }
                else
                {
                        value2 %= value1;
                }
        }
        return Math.Max(value1, value2);
}

    }
}
