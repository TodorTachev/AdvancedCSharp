using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixShuffle
{
    class MatrixShuffle
    {
        static char[,] matrix;
        static char[] input;
        static int counterRight = 0;
        static int counterDown = 0;
        static int counterLeft = 0;
        static int counterUp = 0;
        static int initialRow = 0;
        static int initialCol = 0;
        static StringBuilder text = new StringBuilder();
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new char[n, n];
            InitializeMatrix();
            input = Console.ReadLine().ToCharArray();
            FillMatrixRight(initialRow, initialCol, 0);
            ExtractLetters();
            string bgColor = "#E0000F";
            if (IsTextPalindome())
            {
                bgColor = "#4FE000";
            }
            Console.WriteLine("<div style='background-color:{0}'>{1}</div>", bgColor, text);

        }
        static void FillMatrixRight(int row, int col, int inputIndex)
        {
            if (inputIndex == matrix.GetLength(0) * matrix.GetLength(1))
            {
                matrix[row, col] = input[inputIndex];
                return;
            }
            for (; col < matrix.GetLength(1) - 1 - counterRight; col++)
            {
                matrix[row, col] = input[inputIndex];
                if (inputIndex + 1 == input.Length)
                {
                    return;
                }
                inputIndex++;
            }
            counterRight++;
            FillMatrixDown(row, col, inputIndex);
        }
        static void FillMatrixDown(int row, int col, int inputIndex)
        {
            for (; row < matrix.GetLength(0) - 1 - counterDown; row++)
            {
                matrix[row, col] = input[inputIndex];
                if (inputIndex + 1 == input.Length)
                {
                    return;
                }
                inputIndex++;
            }
            counterDown++;
            FillMatrixLeft(row, col, inputIndex);
        }
        static void FillMatrixLeft(int row, int col, int inputIndex)
        {
            for (; col > 0 + counterLeft; col--)
            {
                matrix[row, col] = input[inputIndex];
                if (inputIndex + 1 == input.Length)
                {
                    return;
                }
                inputIndex++;
            }
            counterLeft++;
            FillMatrixUP(row, col, inputIndex);
        }
        static void FillMatrixUP(int row, int col, int inputIndex)
        {
            for (; row > 0 + counterUp; row--)
            {
                matrix[row, col] = input[inputIndex];
                if (inputIndex + 1 == input.Length)
                {
                    return;
                }
                inputIndex++;
            }
            counterUp++;
            row = initialRow + counterUp;
            col = initialCol + counterUp;
            FillMatrixRight(row, col, inputIndex);
        }
        static void ExtractLetters()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row % 2; col < matrix.GetLength(1); col += 2)
                {
                    text.Append(matrix[row, col]);
                }
            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = (row + 1) % 2; col < matrix.GetLength(1); col += 2)
                {
                    text.Append(matrix[row, col]);
                }
            }
        }
        static bool IsTextPalindome()
        {
            string textStr = text.ToString().Replace(" ", "");
            char[] arr = textStr.ToCharArray();
            Array.Reverse(arr);
            string reversed = new String(arr);
            if (String.Compare(textStr, reversed, true) == 0)
            {
                return true;
            }
            return false;
        }
        static void InitializeMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = ' ';
                }
            }
        }
    }
}
