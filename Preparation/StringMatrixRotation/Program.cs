namespace StringMatrixRotation
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            string rotationCommand = Console.ReadLine();
            int degrees = int.Parse(rotationCommand.Remove(rotationCommand.Length - 1).Remove(0, 7));
            List<string> input = new List<string>();
            int maxInputLineLength = 0;
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "END")
                {
                    break;
                }

                if (inputLine.Length > maxInputLineLength)
                {
                    maxInputLineLength = inputLine.Length;
                }
                input.Add(inputLine);
            }

            char[,] matrix = new char[input.Count, maxInputLineLength];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    try
                    {
                        matrix[row, col] = input[row][col];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            Print(degrees, matrix);
        }

        private static void Print(int degrees, char[,] matrix)
        {
            switch ((degrees / 90) % 4)
            {
                case 0:
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 1:
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        for (int row = matrix.GetUpperBound(0); row >= 0; row--)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 2:
                    for (int row = matrix.GetUpperBound(0); row >= 0; row--)
                    {
                        for (int col = matrix.GetUpperBound(1); col >= 0; col--)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                case 3:
                    for (int col = matrix.GetUpperBound(1); col >= 0; col--)
                    {
                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            Console.Write(matrix[row, col]);
                        }
                        Console.WriteLine();
                    }
                    break;
                default:
                    Console.WriteLine("Cannot print matrix!");
                    break;
            }
        }
    }
}
