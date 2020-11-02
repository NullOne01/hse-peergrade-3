using System;
using System.Collections.Generic;
using System.IO;
using Peergrade3.Localization;

namespace Peergrade3
{
    /// <summary>
    ///     Class that represents matrix.
    /// </summary>
    public class Matrix
    {
        // Max matrix size.
        private const int maxN = 10;
        public Fraction[,] matrixArr;

        /// <summary>
        ///     Get number of rows.
        /// </summary>
        /// <returns> Number of rows. </returns>
        public int RowCount() => matrixArr.GetLength(0);

        /// <summary>
        ///     Get number of columns.
        /// </summary>
        /// <returns> Number of columns. </returns>
        public int ColCount() => matrixArr.GetLength(1);

        /// <summary>
        ///     Get fraction from list matrix. Elements are parsed to fractions.
        /// </summary>
        /// <param name="listMatrix"> List matrix. </param>
        /// <exception cref="ArgumentException"> Problem with list matrix. </exception>
        public Matrix(List<List<string>> listMatrix)
        {
            if (listMatrix.Count > maxN || listMatrix[0].Count > maxN)
            {
                throw new ArgumentException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_TOO_BIG"));
            }

            if (listMatrix.Count <= 0 || listMatrix[0].Count <= 0)
            {
                throw new ArgumentException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_WRONG"));
            }

            int matrixWidth = listMatrix[0].Count;
            matrixArr = new Fraction[listMatrix.Count, listMatrix[0].Count];

            for (int i = 0; i < listMatrix.Count; i++)
            {
                // Matrix list lines should have equal sizes.
                if (listMatrix[i].Count != matrixWidth)
                {
                    throw new ArgumentException(LocalizationManager.getInstance()
                        .GetLocalizedValue("MATRIX_LINES_NOT_EQUAL"));
                }

                for (int j = 0; j < listMatrix[i].Count; j++)
                {
                    matrixArr[i, j] = new Fraction(listMatrix[i][j]);
                }
            }
        }

        /// <summary>
        ///     Get fraction from list matrix.
        /// </summary>
        /// <param name="listMatrix"> List matrix. </param>
        /// <exception cref="ArgumentException"> Problem with list matrix. </exception>
        public Matrix(List<List<Fraction>> listMatrix)
        {
            if (listMatrix.Count > maxN || listMatrix[0].Count > maxN)
            {
                throw new ArgumentException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_TOO_BIG"));
            }

            if (listMatrix.Count <= 0 || listMatrix[0].Count <= 0)
            {
                throw new ArgumentException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_WRONG"));
            }
            
            int matrixWidth = listMatrix[0].Count;
            matrixArr = new Fraction[listMatrix.Count, listMatrix[0].Count];

            for (int i = 0; i < listMatrix.Count; i++)
            {
                if (listMatrix[i].Count != matrixWidth)
                {
                    throw new ArgumentException(LocalizationManager.getInstance()
                        .GetLocalizedValue("MATRIX_LINES_NOT_EQUAL"));
                }

                for (int j = 0; j < listMatrix[i].Count; j++)
                {
                    matrixArr[i, j] = listMatrix[i][j];
                }
            }
        }

        /// <summary>
        ///     Initialization of matrix array.
        /// </summary>
        /// <param name="rowCount"> Number of rows. </param>
        /// <param name="colCount"> Number of columns. </param>
        public Matrix(int rowCount, int colCount)
        {
            matrixArr = new Fraction[rowCount, colCount];
        }

        /// <summary>
        ///     Is the matrix a square?
        /// </summary>
        /// <returns> True if the matrix is a square. Otherwise, false. </returns>
        private bool IsSquare() => ColCount() == RowCount();

        /// <summary>
        ///     Get transposed matrix.
        /// </summary>
        /// <returns> Transposed matrix. </returns>
        public Matrix Transpose()
        {
            Matrix newMatrix = new Matrix(ColCount(), RowCount());

            for (int i = 0; i < RowCount(); i++)
            {
                for (int j = 0; j < ColCount(); j++)
                {
                    newMatrix.matrixArr[j, i] = matrixArr[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>
        ///     Get trace of the matrix.
        /// </summary>
        /// <returns> The trace of the matrix. </returns>
        /// <exception cref="InvalidDataException"> Matrix should be a square. </exception>
        public Fraction Trace()
        {
            if (!IsSquare())
                throw new InvalidDataException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_NOT_SQUARE"));

            var resFraction = new Fraction(0);
            for (int i = 0; i < RowCount(); i++)
            {
                resFraction += matrixArr[i, i];
            }

            return resFraction;
        }

        /// <summary>
        ///     Get determinant of the matrix. Algorithm O(n!).
        /// </summary>
        /// <returns> The determinant of the matrix. </returns>
        public Fraction Determinant()
        {
            if (!IsSquare())
                throw new InvalidDataException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_NOT_SQUARE"));

            if (ColCount() == 1)
                return matrixArr[0, 0];

            var resFraction = new Fraction(0);

            // Finding matrix determinant by decomposition.
            // We are decomposing by row.
            for (int i = 0; i < ColCount(); i++)
            {
                if (i % 2 == 0)
                {
                    resFraction += matrixArr[0, i] * RemoveRowCol(0, i).Determinant();
                }
                else
                {
                    resFraction -= matrixArr[0, i] * RemoveRowCol(0, i).Determinant();
                }
            }

            return resFraction;
        }

        /// <summary>
        ///     Get new matrix from the matrix without row I and column J.
        /// </summary>
        /// <param name="removeI"> Removable row number. </param>
        /// <param name="removeJ"> Removable column number. </param>
        /// <returns> New matrix without row I and column J. </returns>
        private Matrix RemoveRowCol(int removeI, int removeJ)
        {
            var resListRemoved = new List<List<Fraction>>();
            for (int i = 0; i < RowCount(); i++)
            {
                if (i == removeI)
                    continue;

                var listRow = new List<Fraction>();
                for (int j = 0; j < ColCount(); j++)
                {
                    if (j == removeJ)
                        continue;

                    listRow.Add(matrixArr[i, j]);
                }

                resListRemoved.Add(listRow);
            }

            return new Matrix(resListRemoved);
        }

        /// <summary>
        ///     Removes column on the position <paramref name="removeCol"/>
        /// </summary>
        /// <param name="removeCol"> Number of column to be removed. </param>
        /// <returns> New matrix without column. </returns>
        private Matrix RemoveCol(int removeCol)
        {
            Matrix newMatrix = new Matrix(RowCount(), ColCount() - 1);
            for (int i = 0; i < RowCount(); i++)
            {
                // Do we need to move elements?
                bool hasChosen = false;
                
                for (int j = 0; j < ColCount(); j++)
                {
                    if (j == removeCol)
                    {
                        hasChosen = true;
                        continue;
                    }

                    if (hasChosen)
                        newMatrix.matrixArr[i, j - 1] = matrixArr[i, j];
                    else
                        newMatrix.matrixArr[i, j] = matrixArr[i, j];
                }
            }

            return newMatrix;
        }

        /// <summary>
        ///     Replaces column on the position <paramref name="colNum"/> with column <paramref name="newCol"/>.
        /// </summary>
        /// <param name="colNum"> Number of column to be removed. </param>
        /// <param name="newCol"> Column to be set on the position. </param>
        /// <returns> New matrix with replaced column. </returns>
        private Matrix ReplaceCol(int colNum, Fraction[] newCol)
        {
            Matrix newMatrix = new Matrix(RowCount(), ColCount());
            for (int i = 0; i < RowCount(); i++)
            {
                for (int j = 0; j < ColCount(); j++)
                {
                    if (j == colNum)
                    {
                        newMatrix.matrixArr[i, colNum] = newCol[i];
                    }
                    else
                    {
                        newMatrix.matrixArr[i, j] = matrixArr[i, j];
                    }
                }
            }

            return newMatrix;
        }

        /// <summary>
        ///     Get column on the position <paramref name="colNum"/>.
        /// </summary>
        /// <param name="colNum"> Number of the column. </param>
        /// <returns> Column of the matrix. </returns>
        private Fraction[] GetColumn(int colNum)
        {
            var resColumn = new Fraction[RowCount()];
            for (int i = 0; i < RowCount(); i++)
            {
                resColumn[i] = matrixArr[i, colNum];
            }

            return resColumn;
        }

        /// <summary>
        ///     Solving a system of linear equations using Cramer's rule. Algorithm O(n!).
        ///     Input matrix should be (A|b) from A*x=b.
        /// </summary>
        /// <returns> Solved system of linear equations. </returns>
        /// <exception cref="InvalidDataException"> Wrong matrix. </exception>
        public Fraction[] Solve()
        {
            if (ColCount() != RowCount() + 1)
                throw new InvalidDataException(LocalizationManager.getInstance()
                    .GetLocalizedValue("SOLE_ROW_COL_WRONG_SIZE"));

            var fractionListRes = new Fraction[ColCount() - 1];

            Matrix matrixA = RemoveCol(ColCount() - 1);
            Fraction[] columnB = GetColumn(ColCount() - 1);

            //xi * d = di
            Fraction detMatrixA = matrixA.Determinant();

            if (detMatrixA == 0)
            {
                throw new InvalidDataException(LocalizationManager.getInstance()
                    .GetLocalizedValue("SOLE_CANNOT_BE_SOLVED"));
            }

            for (int i = 0; i < matrixA.ColCount(); i++)
            {
                fractionListRes[i] = matrixA.ReplaceCol(i, columnB).Determinant() / detMatrixA;
            }

            return fractionListRes;
        }

        /// <summary>
        ///     Multiplies matrix on -1.
        /// </summary>
        /// <param name="a"> Some matrix. </param>
        /// <returns> Negative matrix. </returns>
        public static Matrix operator -(Matrix a)
        {
            Matrix resMatrix = new Matrix(a.RowCount(), a.ColCount());
            for (int i = 0; i < a.RowCount(); i++)
            {
                for (int j = 0; j < a.ColCount(); j++)
                {
                    resMatrix.matrixArr[i, j] = -a.matrixArr[i, j];
                }
            }

            return resMatrix;
        }

        /// <summary>
        ///     Sum of two matrices.
        /// </summary>
        /// <param name="a"> First matrix. </param>
        /// <param name="b"> Second matrix. </param>
        /// <returns> Som of two matrices. </returns>
        /// <exception cref="InvalidDataException"> Wrong sizes of matrices. </exception>
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (!(a.ColCount() == b.ColCount() && a.RowCount() == b.RowCount()))
                throw new InvalidDataException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_SIZE_NOT_EQUAL"));

            Matrix resMatrix = new Matrix(a.RowCount(), a.ColCount());
            for (int i = 0; i < resMatrix.RowCount(); i++)
            {
                for (int j = 0; j < resMatrix.ColCount(); j++)
                {
                    resMatrix.matrixArr[i, j] = a.matrixArr[i, j] + b.matrixArr[i, j];
                }
            }

            return resMatrix;
        }

        /// <summary>
        ///     Difference of two matrices.
        /// </summary>
        /// <param name="a"> First matrix. </param>
        /// <param name="b"> Second matrix. </param>
        /// <returns> Difference of two matrices. </returns>
        public static Matrix operator -(Matrix a, Matrix b)
        {
            return a + (-b);
        }

        /// <summary>
        ///     Multiplication of two matrices.
        /// </summary>
        /// <param name="a"> First matrix. </param>
        /// <param name="b"> Second matrix. </param>
        /// <returns> Multiplication of two matrices. </returns>
        /// <exception cref="InvalidDataException"> Wrong sizes of matrices. </exception>
        public static Matrix operator *(Matrix a, Matrix b)
        {
            if (a.ColCount() != b.RowCount())
                throw new InvalidDataException(LocalizationManager.getInstance()
                    .GetLocalizedValue("MATRIX_MULT_SIZE_NOT_EQUAL"));

            var resMatrix = new Matrix(a.RowCount(), b.ColCount());
            for (int i = 0; i < a.RowCount(); i++)
            {
                for (int j = 0; j < b.ColCount(); j++)
                {
                    var sumFraction = new Fraction(0);
                    for (int k = 0; k < a.ColCount(); k++)
                    {
                        sumFraction += a.matrixArr[i, k] * b.matrixArr[k, j];
                    }

                    resMatrix.matrixArr[i, j] = sumFraction;
                }
            }

            return resMatrix;
        }

        /// <summary>
        ///     Multiplication of matrix and some fraction. 
        /// </summary>
        /// <param name="a"> Some matrix. </param>
        /// <param name="fraction"> Some fraction. </param>
        /// <returns> Multiplication of matrix and some fraction. </returns>
        public static Matrix operator *(Matrix a, Fraction fraction)
        {
            for (int i = 0; i < a.RowCount(); i++)
            {
                for (int j = 0; j < a.ColCount(); j++)
                {
                    a.matrixArr[i, j] *= fraction;
                }
            }

            return a;
        }
    }
}