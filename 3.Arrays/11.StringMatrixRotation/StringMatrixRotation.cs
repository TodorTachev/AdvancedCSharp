using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        List<string> inputLines = new List<string>();
        string command = Console.ReadLine();
        int maxInputLength = 0;
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            if (input.Length > maxInputLength)
            {
                maxInputLength = input.Length;
            }
            inputLines.Add(input);
        }
        char[,] matrix = new char[inputLines.Count, maxInputLength];
        for (int i = 0; i < inputLines.Count; i++)
        {
            char[] row = inputLines[i].PadRight(maxInputLength, ' ').ToCharArray();
            for (int j = 0; j < maxInputLength; j++)
            {
                matrix[i,j] = row[j];
            }
        }
        Regex rgx = new Regex(@"(\d+)");
        Match match = rgx.Match(command);
        int degrees = int.Parse(match.ToString());
        if (degrees % 360 == 0)
        {
            Print0(matrix);
        }
        if ((degrees - 90) % 360 == 0)
        {
            Print90(matrix);
        }
        if ((degrees - 180) % 360 == 0)
        {
            Print180(matrix);
        }
        if ((degrees - 270) % 360 == 0)
        {
            Print270(matrix);
        }
    }
    static void Print0(char[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
    static void Print90(char[,] matrix)
    {
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = matrix.GetUpperBound(0); row >= 0; row--)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    static void Print180(char[,] matrix)
    {
        for (int row = matrix.GetUpperBound(0); row >= 0; row--)
        {
            for (int col = matrix.GetUpperBound(1); col >= 0; col--)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
    static void Print270(char[,] matrix)
    {
        for (int col = matrix.GetUpperBound(1); col >= 0; col--)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}