using System;
using Peergrade3.Localization;

namespace Peergrade3
{
    /// <summary>
    ///     Class to communicate with user.
    /// </summary>
    public class ProgramScenario
    {
        private const string resultFormat = "{0}: {1}";
        private const string resultFormatLine = "{0}:";

        /// <summary>
        ///     Start of the program.
        /// </summary>
        public void Start()
        {
            MethodsOutput.PrintLocalStringLine("START_MESSAGE");
            MethodsOutput.SkipLine();
            
            MainMenu();
        }

        /// <summary>
        ///     Print main menu, where user can choose methods.
        /// </summary>
        private void MainMenu()
        {
            string line;
            do
            {
                MethodsOutput.PrintLocalStringLine("MAIN_MENU_MESSAGE");

                MethodsOutput.PrintLocalString("INPUT_MAIN_MENU");
                line = MethodsInput.ReadString();
                
                MethodsOutput.SkipLine();
                
                try
                {
                    switch (line)
                    {
                        case "0":
                            LocalizationManager.getInstance().SwitchLocalization();
                            break;
                        case "1":
                            FindTrace();
                            break;
                        case "2":
                            FindTranspose();
                            break;
                        case "3":
                            MatrixSum();
                            break;
                        case "4":
                            MatrixDiff();
                            break;
                        case "5":
                            MatricesMult();
                            break;
                        case "6":
                            MatrixMult();
                            break;
                        case "7":
                            FindDeterminant();
                            break;
                        case "8":
                            MatrixSolve();
                            break;
                    }
                }
                catch (Exception e)
                {
                    MethodsOutput.PrintRedLine(e.Message);
                }
                
                MethodsOutput.PrintSeparator();
            } while (line != "");
        }

        /// <summary>
        ///     Method to find trace.
        /// </summary>
        private void FindTrace()
        {
            var matrix = MethodsInput.ReadMatrix();
            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("TRACE");

            MethodsOutput.PrintStringLine(string.Format(resultFormat, localizedMessage, matrix.Trace()));
        }

        /// <summary>
        ///     Method to find transpose matrix.
        /// </summary>
        private void FindTranspose()
        {
            var matrix = MethodsInput.ReadMatrix();
            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("TRANSPOSE");

            MethodsOutput.PrintStringLine(string.Format(resultFormatLine, localizedMessage));
            MethodsOutput.PrintMatrix(matrix.Transpose());
        }

        /// <summary>
        ///     Method to find sum of 2 matrices.
        /// </summary>
        private void MatrixSum()
        {
            var matrixA = MethodsInput.ReadMatrix();
            var matrixB = MethodsInput.ReadMatrix();
            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("SUM");

            MethodsOutput.PrintStringLine(string.Format(resultFormatLine, localizedMessage));
            MethodsOutput.PrintMatrix(matrixA + matrixB);
        }

        /// <summary>
        ///     Method to find difference of 2 matrices.
        /// </summary>
        private void MatrixDiff()
        {
            var matrixA = MethodsInput.ReadMatrix();
            var matrixB = MethodsInput.ReadMatrix();
            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("DIFFERENCE");

            MethodsOutput.PrintStringLine(string.Format(resultFormatLine, localizedMessage));
            MethodsOutput.PrintMatrix(matrixA - matrixB);
        }

        /// <summary>
        ///     Method to multiply 2 matrices.
        /// </summary>
        private void MatricesMult()
        {
            var matrixA = MethodsInput.ReadMatrix();
            var matrixB = MethodsInput.ReadMatrix();
            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("MULTIPLY");

            MethodsOutput.PrintStringLine(string.Format(resultFormatLine, localizedMessage));
            MethodsOutput.PrintMatrix(matrixA * matrixB);
        }

        /// <summary>
        ///     Method to multiply matrix on some number.
        /// </summary>
        private void MatrixMult()
        {
            var matrix = MethodsInput.ReadMatrix();

            MethodsOutput.PrintLocalStringLine("ENTER_FRACTION");
            var fraction = MethodsInput.ReadFraction();

            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("MULTIPLY");

            MethodsOutput.PrintStringLine(string.Format(resultFormatLine, localizedMessage));
            MethodsOutput.PrintMatrix(matrix * fraction);
        }

        /// <summary>
        ///     Method to find determinant of the matrix.
        /// </summary>
        private void FindDeterminant()
        {
            var matrix = MethodsInput.ReadMatrix();
            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("DETERMINANT");

            MethodsOutput.PrintStringLine(string.Format(resultFormat, localizedMessage, matrix.Determinant()));
        }

        /// <summary>
        ///     Method to solve system of linear equations.
        /// </summary>
        private void MatrixSolve()
        {
            MethodsOutput.PrintLocalStringLine("SOLE_HELP");

            var matrix = MethodsInput.ReadMatrix();
            var localizedMessage = LocalizationManager.getInstance().GetLocalizedValue("RESULT");

            MethodsOutput.PrintStringLine(string.Format(resultFormatLine, localizedMessage));
            MethodsOutput.PrintSolvedSOLE(matrix.Solve());
        }
    }
}