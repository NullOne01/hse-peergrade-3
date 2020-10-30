using System;

namespace Peergrade3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Fraction fraction1 = new Fraction(Console.ReadLine());
                    Fraction fraction2 = new Fraction(Console.ReadLine());
                    Console.WriteLine($"{fraction1} + {fraction2} = {fraction1 + fraction2}");
                    Console.WriteLine($"{fraction1} - {fraction2} = {fraction1 - fraction2}");
                    Console.WriteLine($"{fraction1} * {fraction2} = {fraction1 * fraction2}");
                    Console.WriteLine($"{fraction1} / {fraction2} = {fraction1 / fraction2}");
                    Console.WriteLine("************************");
                }
                catch (Exception)
                {
                    Console.WriteLine("Хуйню вписал, братан");
                }
            }
        }
    }
}