using System;
using System.Numerics;
using Peergrade3.Extensions;
using Peergrade3.Localization;

namespace Peergrade3
{
    /// <summary>
    ///     Class that represents fraction.
    /// </summary>
    public class Fraction
    {
        // We use BigInteger to be able to have big numbers (genius).
        private Tuple<BigInteger, BigInteger> fraction;

        /// <summary>
        ///     Getting fraction from parsing <paramref name="input"/>.
        /// </summary>
        /// <param name="input"> Some string to parse. </param>
        public Fraction(string input)
        {
            ParseInput(input);
        }

        /// <summary>
        ///     Getting fraction from it's <paramref name="numerator"/> and <paramref name="denominator"/>.
        /// </summary>
        /// <param name="numerator"> Numerator of the fraction. </param>
        /// <param name="denominator"> Denominator of the fraction. </param>
        /// <exception cref="DivideByZeroException"> If the denominator equals zero. </exception>
        public Fraction(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException(LocalizationManager.getInstance()
                    .GetLocalizedValue("DIVIDE_BY_ZERO"));

            fraction = new Tuple<BigInteger, BigInteger>(numerator, denominator);
            OptimizeFraction();
        }

        /// <summary>
        ///     Getting fraction from it's numerator.
        /// </summary>
        /// <param name="numerator"> Numerator of the fraction. </param>
        public Fraction(BigInteger numerator)
        {
            fraction = new Tuple<BigInteger, BigInteger>(numerator, 1);
        }

        /// <summary>
        ///     Auto convert fraction into int.
        /// </summary>
        /// <param name="fraction"> Fraction. </param>
        /// <returns> Numerator divided (int) by denominator of <paramref name="fraction"/>. </returns>
        public static implicit operator BigInteger(Fraction fraction)
        {
            return fraction.fraction.Item1 / fraction.fraction.Item2;
        }

        /// <summary>
        ///     Auto convert fraction into double.
        /// </summary>
        /// <param name="fraction"> Fraction. </param>
        /// <returns> Numerator divided by denominator of <paramref name="fraction"/>. </returns>
        public static implicit operator double(Fraction fraction)
        {
            return (double) fraction.fraction.Item1 / (double) fraction.fraction.Item2;
        }

        /// <summary>
        ///     Parse some string to get fraction.
        /// </summary>
        /// <param name="input"> Input to parse. </param>
        /// <exception cref="ArgumentException"> Cannot parse. </exception>
        private void ParseInput(string input)
        {
            if (TryParseIntNum(input))
                return;

            if (TryParseDoubleNum(input))
                return;

            if (TryParseFraction(input))
                return;

            throw new ArgumentException(LocalizationManager.getInstance()
                .GetLocalizedValue("NOT_FRACTION"));
        }

        /// <summary>
        ///     Try to parse int.
        /// </summary>
        /// <param name="input"> Input to parse. </param>
        /// <returns> True if <paramref name="input"/> is int. Otherwise, false. </returns>
        private bool TryParseIntNum(string input)
        {
            if (!BigInteger.TryParse(input, out BigInteger res))
                return false;

            fraction = new Tuple<BigInteger, BigInteger>(res, 1);

            return true;
        }

        /// <summary>
        ///     Try to parse double.
        /// </summary>
        /// <param name="input"> Input to parse. </param>
        /// <returns> True if <paramref name="input"/> is double. Otherwise, false. </returns>
        private bool TryParseDoubleNum(string input)
        {
            if (!double.TryParse(input, out double res))
                return false;

            var numParts = res.ToString().Split('.', ',');
            if (numParts.Length != 2)
                return false;

            var num = BigInteger.Parse(numParts[0] + numParts[1]);
            var dem = (BigInteger) Math.Pow(10, numParts[1].Length);

            fraction = new Tuple<BigInteger, BigInteger>(num, dem);

            return true;
        }

        /// <summary>
        ///     Try to parse some fraction.
        /// </summary>
        /// <param name="input"> Input to parse. </param>
        /// <returns> True if <paramref name="input"/> is fraction. Otherwise, false. </returns>
        /// <exception cref="DivideByZeroException"> We can't divide on zero. s</exception>
        private bool TryParseFraction(string input)
        {
            var strNums = input.Split('/');

            if (strNums.Length != 2)
                return false;

            if (!BigInteger.TryParse(strNums[0], out BigInteger num) || !BigInteger.TryParse(strNums[1], out BigInteger den))
                return false;

            if (den == 0)
                throw new DivideByZeroException(LocalizationManager.getInstance()
                    .GetLocalizedValue("DIVIDE_BY_ZERO"));

            fraction = new Tuple<BigInteger, BigInteger>(num, den);
            OptimizeFraction();

            return true;
        }

        /// <summary>
        ///     Reduce fraction. Move minus into numerator.
        /// </summary>
        private void OptimizeFraction()
        {
            BigInteger gcf = MathExtension.GCF(fraction.Item1, fraction.Item2);
            fraction = new Tuple<BigInteger, BigInteger>(fraction.Item1 / gcf, fraction.Item2 / gcf);

            int sign = fraction.Item2.Sign;
            fraction = new Tuple<BigInteger, BigInteger>(fraction.Item1 * sign, fraction.Item2 * sign);
        }
        
        /// <summary>
        ///     Unary operand that does nothing.
        /// </summary>
        /// <param name="a"> Some fraction. </param>
        /// <returns> Same fraction. </returns>
        public static Fraction operator +(Fraction a) => a;

        /// <summary>
        ///     Unary operand to make negative fraction.
        /// </summary>
        /// <param name="a"> Some fraction. </param>
        /// <returns> Negative fraction. </returns>
        public static Fraction operator -(Fraction a) =>
            new Fraction(-a.fraction.Item1, a.fraction.Item2);

        /// <summary>
        ///     Multiply two fractions.
        /// </summary>
        /// <param name="a"> First fraction. </param>
        /// <param name="b"> Second fraction. </param>
        /// <returns> Fraction that is the result of multiplication two fractions. </returns>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.fraction.Item1 * b.fraction.Item1,
                a.fraction.Item2 * b.fraction.Item2);
        }

        /// <summary>
        ///     Divide the first fraction on the second fraction.
        /// </summary>
        /// <param name="a"> First fraction. </param>
        /// <param name="b"> Second fraction. </param>
        /// <returns> Fraction that is the result of division two fractions. </returns>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return new Fraction(a.fraction.Item1 * b.fraction.Item2,
                a.fraction.Item2 * b.fraction.Item1);
        }

        /// <summary>
        ///     Sum of two fractions.
        /// </summary>
        /// <param name="a"> First fraction. </param>
        /// <param name="b"> Second fraction. </param>
        /// <returns> Sum of two fractions. </returns>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            var numerator = a.fraction.Item1 * b.fraction.Item2 + b.fraction.Item1 * a.fraction.Item2;
            var denominator = a.fraction.Item2 * b.fraction.Item2;

            return new Fraction(numerator, denominator);
        }

        /// <summary>
        ///     Difference between two fractions.
        /// </summary>
        /// <param name="a"> First fraction. </param>
        /// <param name="b"> Second fraction. </param>
        /// <returns> Difference between two fractions. </returns>
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + (-b);
        }

        /// <summary>
        ///     Get string presentation of the fraction.
        /// </summary>
        /// <returns> String presentation. </returns>
        public override string ToString()
        {
            if (fraction.Item2 == 1)
                return $"{fraction.Item1}";
            if (MathExtension.isPowerTen(fraction.Item2))
                return ((double) fraction.Item1 / (double) fraction.Item2).ToString();
            return $"{fraction.Item1}/{fraction.Item2}";
        }
    }
}