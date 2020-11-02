using System;
using System.Collections.Generic;
using System.IO;
using Peergrade3.Localization;

namespace Peergrade3
{
    /// <summary>
    ///     Class to communicate with input.
    /// </summary>
    public static class MethodsInput
    {
        /// <summary>
        ///     Default read line method.
        /// </summary>
        /// <returns> Read line. </returns>
        public static string ReadString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        ///     Read and parse fraction.
        /// </summary>
        /// <returns> Parsed fraction. </returns>
        public static Fraction ReadFraction()
        {
            return new Fraction(Console.ReadLine());
        }

        /// <summary>
        ///     Read matrix line by line, separate elements by spaces.
        /// </summary>
        /// <returns> Matrix. </returns>
        /// <exception cref="InvalidDataException"> There can't such a matrix. </exception>
        public static Matrix ReadMatrix()
        {
            MethodsOutput.PrintLocalStringLine("ENTER_MATRIX");
            var futureMatrixList = new List<List<string>>();

            string line;
            do
            {
                line = ReadString();
                if (line != "")
                    futureMatrixList.Add(new List<string>(line.Split(' ',
                        StringSplitOptions.RemoveEmptyEntries)));
            } while (line != "");

            // If the matrix wasn't entered.
            if (futureMatrixList.Count == 0)
                throw new InvalidDataException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_WRONG"));
            
            return new Matrix(futureMatrixList);
        }
    }
}