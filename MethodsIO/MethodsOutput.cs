using System;
using System.Text;
using Peergrade3.Extensions;
using Peergrade3.Localization;

namespace Peergrade3
{
    /// <summary>
    ///     Class for methods to communicate with output.
    /// </summary>
    public static class MethodsOutput
    {
        /// <summary>
        ///     Print <paramref name="matrix"/> in yellow color, builds special table for the <paramref name="matrix"/>
        /// </summary>
        /// <param name="matrix"> Matrix to print. </param>
        public static void PrintMatrix(Matrix matrix)
        {
            int maxStrNumLength = int.MinValue;

            // Getting max number length.
            for (int i = 0; i < matrix.RowCount(); i++)
            {
                for (int j = 0; j < matrix.ColCount(); j++)
                {
                    maxStrNumLength = Math.Max(matrix.matrixArr[i, j].ToString().Length, maxStrNumLength);
                }
            }

            // Printing matrix.
            for (int i = 0; i < matrix.RowCount(); i++)
            {
                var stringBuilder = new StringBuilder();
                for (int j = 0; j < matrix.ColCount(); j++)
                {
                    // {0, length}.
                    stringBuilder.Append(string.Format($"| {{0, {maxStrNumLength}}} ", matrix.matrixArr[i, j]));
                }

                stringBuilder.Append("|");
                PrintYellowLine(stringBuilder.ToString());
            }
        }

        /// <summary>
        ///     Prints array of variables in format: x1 = ..., x2 = ... and so on.
        /// </summary>
        /// <param name="res"> Values of variables. </param>
        public static void PrintSolvedSOLE(Fraction[] res)
        {
            for (int i = 0; i < res.Length; i++)
            {
                PrintGreenLine($"x{i + 1} = {res[i]}");
            }
        }

        /// <summary>
        ///     <inheritdoc cref="PrintInColor"/> Skips line after.
        /// </summary>
        /// <param name="input"> <inheritdoc cref="PrintInColor"/> </param>
        /// <param name="color"> <inheritdoc cref="PrintInColor"/> </param>
        public static void PrintInColorLine(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ResetColor();
        }

        /// <summary>
        ///     Print some line using <paramref name="color"/>.
        /// </summary>
        /// <param name="input"> Some text to print. </param>
        /// <param name="color"> Some color to print text. </param>
        public static void PrintInColor(string input, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(input);
            Console.ResetColor();
        }

        /// <summary>
        ///     Prints green text. Skips line after.
        /// </summary>
        /// <param name="input"> Some text to print. </param>
        public static void PrintGreenLine(string input)
        {
            PrintInColorLine(input, ConsoleColor.Green);
        }

        /// <summary>
        ///     Prints yellow text. Skips line after.
        /// </summary>
        /// <param name="input"> Some text to print. </param>
        public static void PrintYellowLine(string input)
        {
            PrintInColorLine(input, ConsoleColor.Yellow);
        }

        /// <summary>
        ///     Prints red text. Skips line after.
        /// </summary>
        /// <param name="input"> Some text to print. </param>
        public static void PrintRedLine(string input)
        {
            PrintInColorLine(input, ConsoleColor.Red);
        }

        /// <summary>
        ///     Printing <paramref name="arr" /> elements into the console.
        ///     Elements are separated by <paramref name="separator" />.
        /// </summary>
        /// <param name="arr"> Array to print. </param>
        /// <param name="separator"> Separator after each array element. </param>
        /// <param name="prefix"> Prefix before each array element. </param>
        /// <typeparam name="T"> Type of array elements. </typeparam>
        public static void PrintArray<T>(T[] arr, string separator = "", string prefix = "")
        {
            foreach (var element in arr) PrintString(prefix + element + separator);
        }

        /// <summary>
        ///     Printing <paramref name="line" /> into the console with formatting <paramref name="args" />.
        /// </summary>
        /// <param name="line"> Line to print. </param>
        /// <param name="args"> Arguments for <paramref name="line" />. </param>
        public static void PrintString(string line, params object[] args)
        {
            Console.Write(line.BetterFormat(args));
        }

        /// <summary>
        ///     <inheritdoc cref="PrintString" />
        ///     Skips line after.
        /// </summary>
        /// <param name="line">
        ///     <inheritdoc cref="PrintString" />
        /// </param>
        /// <param name="args">
        ///     <inheritdoc cref="PrintString" />
        /// </param>
        public static void PrintStringLine(string line, params object[] args)
        {
            Console.WriteLine(line.BetterFormat(args));
        }

        /// <summary>
        ///     Just skipping 1 line in console.
        /// </summary>
        public static void SkipLine()
        {
            Console.WriteLine();
        }
        
        /// <summary>
        ///     Printing "******************" into console.
        /// </summary>
        public static void PrintSeparator()
        {
            SkipLine();
            PrintStringLine("******************");
            SkipLine();
        }

        /// <summary>
        ///     Writing localized value by <paramref name="key" /> into the console with formatting <paramref name="args" />.
        /// </summary>
        /// <param name="key"> The key of a localized value. </param>
        /// <param name="args"> Arguments for <paramref name="key" />. </param>
        public static void PrintLocalString(string key, params object[] args)
        {
            Console.Write(LocalizationManager.getInstance().GetLocalizedValue(key, args));
        }

        /// <summary>
        ///     <inheritdoc cref="PrintLocalString" />
        ///     Skips line after.
        /// </summary>
        /// <param name="key">
        ///     <inheritdoc cref="PrintLocalString" />
        /// </param>
        /// <param name="args">
        ///     <inheritdoc cref="PrintLocalString" />
        /// </param>
        public static void PrintLocalStringLine(string key, params object[] args)
        {
            Console.WriteLine(LocalizationManager.getInstance().GetLocalizedValue(key, args));
        }
    }
}