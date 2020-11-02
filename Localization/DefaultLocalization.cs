using System;
using System.Collections.Generic;

namespace Peergrade3.Localization
{
    /// <summary>
    ///     Class of default localization text. English text.
    /// </summary>
    public class DefaultLocalization
    {
        public Dictionary<string, string> localDict = new Dictionary<string, string>
        {
            {"TEST", "TEST. "},
            {"UNDEFINED", "Undefined. "},
            {
                "ENTER_MATRIX", "Enter matrix (max 10x10) line by line, separate elements by space, " + Environment.NewLine +
                                "you can type empty line to end filling: "
            },
            {"MATRIX_LINES_NOT_EQUAL", "Matrix should have equal number of elements on each line. "},
            {"DIVIDE_BY_ZERO", "You can't divide number by zero. "},
            {"NOT_FRACTION", "Can't parse into fraction or number. Or number is just too big. "},
            {"MATRIX_NOT_SQUARE", "Matrix is not a square. "},
            {"MATRIX_SIZE_NOT_EQUAL", "Matrices have not equal size. "},
            {"MATRIX_MULT_SIZE_NOT_EQUAL", "Matrix 1 column count is not equal to Matrix 2 row count. "},
            {"SOLE_ROW_COL_WRONG_SIZE", "Matrix should have (column size = row size + 1). "},
            {"SOLE_CANNOT_BE_SOLVED", "SOLE is inconsistent or have many answers. "},
            {
                "START_MESSAGE", "Welcome to some matrix calculator. You can use here fractions." +
                                 Environment.NewLine +
                                 "Example: 1/3, 0.5, 5 <- all these numbers work here."
            },
            {
                "MAIN_MENU_MESSAGE", "Type a number of operation. Pass empty line if you want to exit" +
                                     Environment.NewLine +
                                     "What you want to do?" + Environment.NewLine +
                                     "0. Change language" + Environment.NewLine +
                                     "1. Find trace" + Environment.NewLine +
                                     "2. Find transpose" + Environment.NewLine +
                                     "3. Matrices sum" + Environment.NewLine +
                                     "4. Matrices difference" + Environment.NewLine +
                                     "5. Matrices multiply" + Environment.NewLine +
                                     "6. Matrix multiply on some number" + Environment.NewLine +
                                     "7. Find determinant" + Environment.NewLine +
                                     "8. Solve SOLE (A * x = b). Works if det(A) is not zero. "
            },
            {"INPUT_MAIN_MENU", "Input operation number or pass empty line to end program: "},
            {"TRACE", "Trace"},
            {"TRANSPOSE", "Transpose"},
            {"SUM", "Sum"},
            {"DIFFERENCE", "Difference"},
            {"MULTIPLY", "Multiply"},
            {"DETERMINANT", "Determinant"},
            {"RESULT", "Result"},
            {
                "SOLE_HELP", "You have some SOLE. You need to solve A*x=b, where " + Environment.NewLine +
                             "A - matrix of the elements" + Environment.NewLine +
                             "x - vector-column of unknown variables, " + Environment.NewLine +
                             "b - vector-column of free elements." + Environment.NewLine +
                             "Write matrix (A|b) to solve SLOE, don't write symbol (|): "
            },
            {"MATRIX_WRONG", "Wrong matrix."},
            {"MATRIX_TOO_BIG", "Matrix is too big."}
        };
    }
}