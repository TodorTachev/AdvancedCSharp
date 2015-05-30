using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace TextGravity
{
    class TextGravity
    {
        static void Main(string[] args)
        {
            double n = double.Parse(Console.ReadLine());
            char[] input = Console.ReadLine().ToCharArray();
            char[,] matrix = new char[(int)Math.Ceiling(input.Length / n), (int)n];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = ' ';
                }
            }
            TextToMatrix(input, matrix);
            while (IsThereMoreMoves(matrix))
            {
                for (int row = matrix.GetUpperBound(0) - 1; row >= 0; row--)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (matrix[row + 1, col] == ' ')
                        {
                            matrix[row + 1, col] = matrix[row, col];
                            matrix[row, col] = ' ';
                        }
                    }
                }
            }
            Console.Write("<table>");
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write("<tr>");
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("<td>" + SecurityElement.Escape(matrix[row, col].ToString()) + "</td>");
                }
                Console.Write("</tr>");
            }
            Console.WriteLine("</table>");
        }

        private static void TextToMatrix(char[] input, char[,] matrix)
        {
            int index = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[index];
                    if (index + 1 == input.Length)
                    {
                        return;
                    }
                    index++;
                }
            }
        }

        private static bool IsThereMoreMoves(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != ' ' && matrix[row + 1, col] == ' ')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
