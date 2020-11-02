using System.Numerics;

namespace Peergrade3.Extensions
{
    public static class MathExtension
    {
        /// <summary>
        ///     Get greatest common factor of two numbers.
        /// </summary>
        /// <param name="a"> First number. </param>
        /// <param name="b"> Second number. </param>
        /// <returns> Greatest common factor of two numbers. </returns>
        public static BigInteger GCF(BigInteger a, BigInteger b)
        {
            while (b != 0)
            {
                BigInteger temp = b;
                b = a % b;
                a = temp;
            }
            
            return a;
        }
        
        /// <summary>
        ///     Get least common multiple of two numbers.
        /// </summary>
        /// <param name="a"> First number. </param>
        /// <param name="b"> Second number. </param>
        /// <returns> Least common multiple of two numbers. </returns>
        public static BigInteger LCM(BigInteger a, BigInteger b)
        {
            return (a / GCF(a, b)) * b;
        }

        /// <summary>
        ///     Does <paramref name="n"/> equal: 10, 100, 1000... and so on.
        /// </summary>
        /// <param name="n"> Some number. </param>
        /// <returns> True if number equals to 10, 100, 1000... Otherwise, false. </returns>
        public static bool isPowerTen(BigInteger n)
        {
            while (n != 0)
            {
                if (n != 1 && n % 10 != 0)
                    return false;
                
                n /= 10;
            }

            return true;
        }
    }
}