namespace TextGravity
{
    using System;
    using System.Security;

    class Program
    {
        static void Main()
        {
            int lineLength = int.Parse(Console.ReadLine());
            string text = Console.ReadLine();

            char[,] matrix = new char[(int)Math.Ceiling(text.Length / (double)lineLength), lineLength];
            int index = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (index == text.Length)
                    {
                        matrix[row, col] = ' ';
                    }
                    else
                    {
                        matrix[row, col] = text[index];
                        index++;
                    }
                }
            }
            
            while (CheckForSpaceBetweenLetters(matrix))
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

        private static bool CheckForSpaceBetweenLetters(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetUpperBound(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row + 1, col] == ' ' && matrix[row, col] != ' ')
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
