using System;

namespace Peergrade3
{
    public static class MathExtension
    {
        public static int GCF(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            
            return a;
        }
        
        public static int LCM(int a, int b)
        {
            return (a / GCF(a, b)) * b;
        }
    }
}