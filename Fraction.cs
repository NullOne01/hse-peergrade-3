using System;

namespace Peergrade3
{
    public class Fraction
    {
        private Tuple<int, int> fraction;

        public Fraction(string input)
        {
            ParseInput(input);
        }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException();
            
            fraction = new Tuple<int, int>(numerator, denominator);
            OptimizeFraction();
        }

        private void ParseInput(string input)
        {
            if (TryParseIntNum(input))
                return;

            if (TryParseDoubleNum(input))
                return;
            
            if (TryParseFraction(input))
                return;

            throw new ArgumentException();
        }

        private bool TryParseIntNum(string input)
        {
            if (!int.TryParse(input, out int res)) 
                return false;
            
            fraction = new Tuple<int, int>(res, 1);

            return true;

        }
        
        private bool TryParseDoubleNum(string input)
        {
            if (!double.TryParse(input, out double res)) 
                return false;
            
            var numParts = res.ToString().Split('.', ',');
            if (numParts.Length != 2)
                return false;

            var num = int.Parse(numParts[0] + numParts[1]);
            var dem = (int) Math.Pow(10, numParts[1].Length);
                
            fraction = new Tuple<int, int>(num, dem);

            return true;
        }

        private bool TryParseFraction(string input)
        {
            string[] strNums = input.Split('/');

            if (strNums.Length != 2)
                return false;

            if (!int.TryParse(strNums[0], out int num) || !int.TryParse(strNums[1], out int den))
                return false;

            if (den == 0)
                throw new DivideByZeroException();

            fraction = new Tuple<int, int>(num, den);
            OptimizeFraction();
            
            return true;
        }

        private void OptimizeFraction()
        {
            int gcf = MathExtension.GCF(fraction.Item1, fraction.Item2);
            fraction = new Tuple<int, int>(fraction.Item1 / gcf, fraction.Item2 / gcf);

            int sign = Math.Sign(fraction.Item2);
            fraction = new Tuple<int, int>(fraction.Item1 * sign, fraction.Item2 * sign);
        }

        
        public static Fraction operator +(Fraction a) => a;
        
        public static Fraction operator -(Fraction a) => 
            new Fraction(-a.fraction.Item1, a.fraction.Item2);
        
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.fraction.Item1 * b.fraction.Item1,
                a.fraction.Item2 * b.fraction.Item2);
        }
        
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.fraction.Item1 * b.fraction.Item2,
                a.fraction.Item2 * b.fraction.Item1);
        }
        
        public static Fraction operator +(Fraction a, Fraction b)
        {
            var numerator = a.fraction.Item1 * b.fraction.Item2 + b.fraction.Item1 * a.fraction.Item2;
            var denominator = a.fraction.Item2 * b.fraction.Item2;

            return new Fraction(numerator, denominator);
        }
        
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + (-b);
        }
        
        public override string ToString()
        {
            if (fraction.Item2 == 1)
                return $"{fraction.Item1}";
            return $"{fraction.Item1}/{fraction.Item2}";
        }
    }
}