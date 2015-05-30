//Write a program that reads a rectangular integer matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements. 
//On the first line, you will receive the rows N and columns M. On the next N lines you will receive each row with its columns.
//Print the elements of the 3 x 3 square as a matrix, along with their sum.

using System;

class MaximalSum
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int[,] mtrx = new int[n, m];
        string[] input = new string[m];
        for (int row = 0; row < mtrx.GetLength(0); row++)
        {
            input = Console.ReadLine().Split(' ');
            for (int col = 0; col < mtrx.GetLength(1); col++)
            {
                mtrx[row, col] = int.Parse(input[col]);
            }
        }
        int sum = 0;
        int tempSum = 0;
        int a = -1;
        int b = -1;
        for (int row = 0; row < mtrx.GetLength(0) - 2; row++)
        {
            for (int col = 0; col < mtrx.GetLength(1) - 2; col++)
            {
                tempSum = mtrx[row, col] + mtrx[row, col + 1] + mtrx[row, col + 2] +
                          mtrx[row + 1, col] + mtrx[row + 1, col + 1] + mtrx[row + 1, col + 2] +
                          mtrx[row + 2, col] + mtrx[row + 2, col + 1] + mtrx[row + 2, col + 2];
                if (tempSum > sum)
                {
                    sum = tempSum;
                    a = row;
                    b = col;
                }
            }
        }
        Console.WriteLine(sum);
        for (int row = a; row <= 3; row++)
        {
            for (int col = b; col <= 3; col++)
            {
                Console.Write("{0,3}", mtrx[row, col]);
            }
            Console.WriteLine();
        }
    }
}