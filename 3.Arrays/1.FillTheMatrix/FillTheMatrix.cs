using System;

class FillTheMatrix
{
    static void Main()
    {
        Console.Write("Enter matrix size: ");
        int n =  int.Parse(Console.ReadLine());
        int[,] matrix1 = new int[n, n];
        int[,] matrix2 = new int[n, n];
        int counter = 1;
        for (int col = 0; col < matrix1.GetLength(1); col++)
        {
            for (int row = 0; row < matrix1.GetLength(0); row++)
            {
                matrix1[row, col] = counter;
                counter++;
            }
        }
        counter = 1;
        for (int col = 0; col < matrix2.GetLength(1); col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < matrix2.GetLength(0); row++)
                {
                    matrix2[row, col] = counter;
                    counter++;
                }
            }
            else
            {
                for (int row = matrix2.GetLength(0) - 1; row >= 0; row--)
                {
                    matrix2[row, col] = counter;
                    counter++;
                }
            }
        }
        PrintMatrix(matrix1);
        Console.WriteLine("-------------------------------------");
        PrintMatrix(matrix2);
    }
    static void PrintMatrix(int[,] arr)
    {
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                Console.Write(arr[row, col].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}