using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixShuffle
{
    class Program
    {
        private static char[,] matrix;
        private static int currentRow;
        private static int currentCol;
        private static int breakRow;
        private static int breakCol;
        private static int counterRight = 0;
        private static int counterDown = 0;
        private static int counterLeft = 0;
        private static int counterUp = 0;
        private static int index = 0;
        private static string direction;

        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            matrix = new char[size, size];
            currentRow = 0;
            currentCol = 0;
            direction = "right";

            if (size % 2 == 0)
            {
                breakRow = size / 2;
                breakCol = size / 2 - 1;
            }
            else
            {
                breakRow = size / 2;
                breakCol = size / 2;
            }

            do
            {
                switch (direction)
                {
                    case "right":
                        FillRight(text);
                        break;
                    case "down":
                        FillDown(text);
                        break;
                    case "left":
                        FillLeft(text);
                        break;
                    case "up":
                        FillUp(text);
                        break;
                }
                
            } while (currentRow != breakRow || currentCol != breakCol);

            StringBuilder extractedText = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row % 2; col < matrix.GetLength(1); col += 2)
                {
                    extractedText.Append(matrix[row, col]);
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = (row + 1) % 2; col < matrix.GetLength(1); col += 2)
                {
                    extractedText.Append(matrix[row, col]);
                }
            }

            string result = extractedText.ToString();

            Console.WriteLine("<div style='background-color:#{0}'>{1}</div>", IsPalindrome(result) ? "4FE000" : "E0000F", result);


        }

        private static bool IsPalindrome(string text)
        {
            text = text.Replace(" ", string.Empty);
            var arr = text.ToCharArray();
            Array.Reverse(arr);
            string reversed = arr.ToString();
            if (text.ToLower().CompareTo(reversed.ToLower()) == 0)
            {
                return true;
            }
            return false;
        }

        private static void FillRight(string text)
        {
            counterRight++;
            while (currentCol < matrix.GetLength(1) - counterRight)
            {
                if (index < text.Length)
                {
                    matrix[currentRow, currentCol] = text[index];
                    index++;
                    currentCol++;
                }
                else
                {
                    matrix[currentRow, currentCol] = ' ';
                    currentCol++;
                }
            }
            direction = "down";
        }

        private static void FillDown(string text)
        {
            counterDown++;
            while (currentRow < matrix.GetLength(0) - counterDown)
            {
                if (index < text.Length)
                {
                    matrix[currentRow, currentCol] = text[index];
                    index++;
                    currentRow++;
                }
                else
                {
                    matrix[currentRow, currentCol] = ' ';
                    currentRow++;
                }
            }
            direction = "left";
        }

        private static void FillLeft(string text)
        {
            counterLeft++;
            while (currentCol >= counterLeft)
            {
                if (index < text.Length)
                {
                    matrix[currentRow, currentCol] = text[index];
                    index++;
                    currentCol--;
                }
                else
                {
                    matrix[currentRow, currentCol] = ' ';
                    currentCol--;
                }
            }
            direction = "up";
        }

        private static void FillUp(string text)
        {
            counterUp++;
            while (currentRow >= counterLeft)
            {
                if (index < text.Length)
                {
                    matrix[currentRow, currentCol] = text[index];
                    index++;
                    currentRow--;
                }
                else
                {
                    matrix[currentRow, currentCol] = ' ';
                    currentRow--;
                }
            }
            currentCol++;
            currentRow++;
            direction = "right";
        }
    }
}
