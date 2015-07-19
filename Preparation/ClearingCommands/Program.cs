using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;

namespace ClearingCommands
{
    class Program
    {
        static void Main()
        {
            List<string> input = new List<string>();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "END")
                {
                    break;
                }
                input.Add(inputLine);
            }

            char[,] maze = new char[input.Count, input[0].Length];
            int currentRow;
            int currentCol;

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    maze[row, col] = input[row][col];
                }
            }

            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    currentRow = row;
                    currentCol = col;
                    switch (maze[row, col])
                    {
                        case '>':
                            while (currentCol + 1 < maze.GetLength(1) &&
                                   maze[row, currentCol + 1] != '>' &&
                                   maze[row, currentCol + 1] != 'v' &&
                                   maze[row, currentCol + 1] != '<' &&
                                   maze[row, currentCol + 1] != '^')
                            {
                                currentCol++;
                                maze[row, currentCol] = ' ';
                            }
                            break;
                        case '<':
                            while (currentCol - 1 >= 0 &&
                                   maze[row, currentCol - 1] != '>' &&
                                   maze[row, currentCol - 1] != 'v' &&
                                   maze[row, currentCol - 1] != '<' &&
                                   maze[row, currentCol - 1] != '^')
                            {
                                currentCol--;
                                maze[row, currentCol] = ' ';
                            }
                            break;
                        case '^':
                            while (currentRow - 1 >= 0 &&
                                   maze[currentRow - 1, col] != '>' &&
                                   maze[currentRow - 1, col] != 'v' &&
                                   maze[currentRow - 1, col] != '<' &&
                                   maze[currentRow - 1, col] != '^')
                            {
                                currentRow--;
                                maze[currentRow, col] = ' ';
                            }
                            break;
                        case 'v':
                            while (currentRow + 1 < maze.GetLength(0) &&
                                   maze[currentRow + 1, col] != '>' &&
                                   maze[currentRow + 1, col] != 'v' &&
                                   maze[currentRow + 1, col] != '<' &&
                                   maze[currentRow + 1, col] != '^')
                            {
                                currentRow++;
                                maze[currentRow, col] = ' ';
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                Console.Write("<p>");
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    Console.Write(SecurityElement.Escape(maze[row, col].ToString()));
                }
                Console.WriteLine("</p>");
            }
        }
    }
}
