using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CollectTheCoins
{
    static void Main()
    {
        char[][] board = new char[4][];
        for (int i = 0; i < 4; i++)
        {
            board[i] = Console.ReadLine().ToCharArray();
        }
        char[] commands = Console.ReadLine().ToCharArray();
        int counterCoins = 0;
        int counterWalls = 0;
        int currentRow = 0;
        int currentCol = 0;

        for (int index = 0; index < commands.Length; index++)
        {
            switch (commands[index])
            {
                case '^':
                    {
                        currentRow--;
                        if (currentRow < 0)
                        {
                            currentRow++;
                            counterWalls++;
                        }
                        else
                        {
                            if (board[currentRow][currentCol] == '$')
                            {
                                counterCoins++;
                            }
                        }
                    }
                    break;
                case 'v':
                    {
                        currentRow++;
                        if (currentCol >= board[currentRow].Length || currentRow > 4)
                        {
                            currentRow--;
                            counterWalls++;
                        }
                        else
                        {
                            if (board[currentRow][currentCol] == '$')
                            {
                                counterCoins++;
                            }
                        }
                    }
                    break;
                case '>':
                    {
                        currentCol++;
                        if (currentCol >= board[currentRow].Length)
                        {
                            currentCol--;
                            counterWalls++;
                        }
                        else
                        {
                            if (board[currentRow][currentCol] == '$')
                            {
                                counterCoins++;
                            }
                        }
                    }
                    break;
                case '<':
                    {
                        currentCol--;
                        if (currentCol < 0)
                        {
                            currentRow++;
                            counterWalls++;
                        }
                        else
                        {
                            if (board[currentRow][currentCol] == '$')
                            {
                                counterCoins++;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("Coins: " + counterCoins + " Walls: " + counterWalls);
    }
}