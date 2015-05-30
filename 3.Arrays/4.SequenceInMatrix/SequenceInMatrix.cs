//


using System;

class SequenceInMatrix
{
    
    
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int width = n;
        int height = m;
        string[,] mtrx = new string[n, m];
        string[] input = new string[n];
        for (int row = 0; row < mtrx.GetLength(0); row++)
        {
            input = Console.ReadLine().Split(' ');
            for (int col = 0; col < mtrx.GetLength(1); col++)
            {
                mtrx[row, col] = input[col];
            }
        }
        int counter = 1;
        int best = 0;
        int bestRowIndex = -1;
        int bestColIndex = -1;
        //check right diagonal from main up
        for (int i = 0; i < (width + height - 3) / 2 + 1; i++)
        {
            for (int j = 0, k = 0 + i; j < width - 1; j++)
            {
                if (mtrx[j, k] == mtrx[j + 1, k + 1])
                {
                    counter++;
                }
                else if (best < counter)
                {
                    bestRowIndex = j;
                    bestColIndex = k;
                    best = counter;
                    counter = 1;
                }
            }
            width--;
        }
        string[] result1 = new string[best];
        for (int i = 0; i < best; i++)
        {
            result1[i] = mtrx[bestRowIndex, bestColIndex];
        }

        counter = 1;
        best = 0;
        bestRowIndex = -1;
        bestColIndex = -1;
        //check right diagonal from main down
        for (int i = 1; i < (width + height - 3) / 2 + 1; i++)
        {
            for (int j = 0, k = 0 + i; j < width - 1; j++)
            {
                if (mtrx[k, j] == mtrx[k + 1, j + 1])
                {
                    counter++;
                }
                else if (best < counter)
                {
                    bestRowIndex = k;
                    bestColIndex = j;
                    best = counter;
                    counter = 1;
                }
            }
            width--;
        }
        string[] result2 = new string[best];
        for (int i = 0; i < best; i++)
        {
            result2[i] = mtrx[bestRowIndex, bestColIndex];
        }

        counter = 1;
        best = 0;
        bestRowIndex = -1;
        bestColIndex = -1;
        //check left diagonal from main up
        for (int i = 0; i < (width + height - 3) / 2 + 1; i++)
        {
            for (int j = 0, k = width - 1 - i; j < width - 1; j++)
            {
                if (mtrx[j, k] == mtrx[j + 1, k - 1])
                {
                    counter++;
                }
                else if (best < counter)
                {
                    bestRowIndex = j;
                    bestColIndex = k;
                    best = counter;
                    counter = 1;
                }
            }
            width--;
        }
        string[] result3 = new string[best];
        for (int i = 0; i < best; i++)
        {
            result3[i] = mtrx[bestRowIndex, bestColIndex];
        }

        counter = 1;
        best = 0;
        bestRowIndex = -1;
        bestColIndex = -1;
        //check left diagonal from main down
        for (int i = 0; i < (width + height - 3) / 2; i++)
        {
            for (int j = 1, k = width - 1 - i; j < width - 1; j++
            {
                if (mtrx[j, k] == mtrx[j + 1, k - 1])
                {
                    counter++;
                }
                else if (best < counter)
                {
                    bestRowIndex = j;
                    bestColIndex = k;
                    best = counter;
                    counter = 1;
                }
            }
            width--;
        }
        string[] result4 = new string[best];
        for (int i = 0; i < best; i++)
        {
            result3[i] = mtrx[bestRowIndex, bestColIndex];
        }
    }
    static void CheckDiagonals(string[,] matrix, int width, int height)
    {
        int upCounter = 1;
        int downCounter = 1;
        int upRowIndex;
        int upColIndex;
        int downRowIndex;
        int downColIndex;
        int upBest = 0;
        int downBest = 0;

        for (int i = 0; i < (width + height - 3) / 2 + 1; i++)
        {
            for (int j = 0, k = 0 + i; j < width - 1; j++, k++)
            {
                if (matrix[j, k] == matrix[j + 1, k + 1])
                {
                    upCounter++;
                }
                else if (upBest < upCounter)
                {
                    upRowIndex = j;
                    upColIndex = k;
                    upBest = upCounter;
                    upCounter = 1;
                }
                if (matrix[k, j] == matrix[k + 1, j + 1])
                {
                    downCounter++;
                }
                else if (downBest < downCounter)
                {
                    downRowIndex = k;
                    downColIndex = j;
                    downBest = downCounter;
                    downCounter = 1;
                }
            }
            width--;
        }
    }
}