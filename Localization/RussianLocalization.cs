using System;
using System.Collections.Generic;

namespace Peergrade3.Localization
{
    /// <summary>
    ///     Class of russian localization.
    /// </summary>
    public class RussianLocalization : DefaultLocalization
    {
        public RussianLocalization()
        {
            localDict = new Dictionary<string, string>
            {
                {"TEST", "Тест. "},
                {"UNDEFINED", "Неопределенно. "},
                {
                    "ENTER_MATRIX", "Введите матрицу (макс. 10x10) по строчкам, разделяйте числа пробелами. " + Environment.NewLine +
                                    "Напишите простую строку, чтобы закончить ввод матрицы: "
                },
                {"MATRIX_LINES_NOT_EQUAL", "Матрица должна иметь одинаковое количество элементов на каждой строчке. "},
                {"DIVIDE_BY_ZERO", "Нельзя делить на нуль. "},
                {"NOT_FRACTION", "Невозможно получить дробь или число. Или число слишком большое. "},
                {"MATRIX_NOT_SQUARE", "Матрица не квадратична. "},
                {"MATRIX_SIZE_NOT_EQUAL", "Матрицы имеют разные размерности. "},
                {"MATRIX_MULT_SIZE_NOT_EQUAL", "Количество столбцов матрицы 1 должно равняться количеству строк матрицы 2. "},
                {"SOLE_ROW_COL_WRONG_SIZE", "Матрица должна иметь правильную размерность (количество столбцов = количество строк + 1). "},
                {"SOLE_CANNOT_BE_SOLVED", "СЛАУ не имеет решения или имеет много решений. "},
                {
                    "START_MESSAGE", "Добро пожаловать в калькулятор матриц. Здесь можно использовать дроби." +
                                     Environment.NewLine +
                                     "Например: 1/3, 0.5, 5 <- все эти числа будут здесь работать."
                },
                {
                    "MAIN_MENU_MESSAGE", "Введите номер нужной операции. Введите пустую строку, чтобы выйти" +
                                         Environment.NewLine +
                                         "Что вам надо?" + Environment.NewLine +
                                         "0. Сменить язык" + Environment.NewLine +
                                         "1. Найти след" + Environment.NewLine +
                                         "2. Найти транспонированную матрицу" + Environment.NewLine +
                                         "3. Сумма матриц" + Environment.NewLine +
                                         "4. Разность матриц" + Environment.NewLine +
                                         "5. Произведение матриц" + Environment.NewLine +
                                         "6. Умножение матрицы на число" + Environment.NewLine +
                                         "7. Найти определитель" + Environment.NewLine +
                                         "8. Решить СЛАУ (A * x = b). Работает, если det(A) не равно нулю. "
                },
                {"INPUT_MAIN_MENU", "Введите номер операции или напишите пустую строку: "},
                {"TRACE", "След"},
                {"TRANSPOSE", "Транспонированная матрица"},
                {"SUM", "Сумма"},
                {"DIFFERENCE", "Разность"},
                {"MULTIPLY", "Произведение"},
                {"DETERMINANT", "Определитель"},
                {"RESULT", "Результат"},
                {
                    "SOLE_HELP", "У вас есть СЛАУ. Вам нужно решить A*x=b, где " + Environment.NewLine +
                                 "A - матрица системы" + Environment.NewLine +
                                 "x - вектор-столбец неизвестных переменных, " + Environment.NewLine +
                                 "b - вектор-столбец свободных членов." + Environment.NewLine +
                                 "Напишите матрицу (A|b), чтобы решить матрицу, не надо вводить символ (|): "
                },
                {"MATRIX_WRONG", "Неправильная матрица."},
                {"MATRIX_TOO_BIG", "Матрица слишком большая."},
                {"ENTER_FRACTION", "Введите число или дробь: "}
            };
        }
    }
}