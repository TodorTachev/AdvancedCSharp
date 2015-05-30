using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;

namespace ClearingCommands
{
    class ClearingCommands
    {
        static string escapedLeft = System.Security.SecurityElement.Escape("<");
        static string escapedRight = System.Security.SecurityElement.Escape(">");
        static void Main()
        {
            List<string[]> inputList = new List<string[]>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                string[] inputArr = input.Select(x => x.ToString()).ToArray();
                inputList.Add(inputArr);
            }
            string[,] inputMtrx = new string[inputList.Count, inputList[0].Length];
            for (int row = 0; row < inputMtrx.GetLength(0); row++)
            {
                for (int col = 0; col < inputMtrx.GetLength(1); col++)
                {
                    inputMtrx[row, col] = inputList[row][col];
                }
            }
            for (int row = 0; row < inputMtrx.GetLength(0); row++)
            {
                for (int col = 0; col < inputMtrx.GetLength(1); col++)
                {
                    if (inputMtrx[row, col] == ">")
                    {
                        CommandRight(inputMtrx, row, col);
                    }
                    if (inputMtrx[row, col] == "<")
                    {
                        CommandLeft(inputMtrx, row, col);
                    }
                    if (inputMtrx[row, col] == "v")
                    {
                        CommandDown(inputMtrx, row, col);
                    }
                    if (inputMtrx[row, col] == "^")
                    {
                        CommandUp(inputMtrx, row, col);
                    }
                }
            }
            
            PrintMatrix(inputMtrx);
        }
        static void CommandRight(string[,] inputMtrx, int row, int col)
        {
            while (col + 1 != inputMtrx.GetLength(1) && inputMtrx[row, col + 1] != ">" &&
                                                        inputMtrx[row, col + 1] != "<" &&
                                                        inputMtrx[row, col + 1] != "v" &&
                                                        inputMtrx[row, col + 1] != "^")
            {
                inputMtrx[row, col + 1] = " ";
                col++;
            }
        }
        static void CommandDown(string[,] inputMtrx, int row, int col)
        {
            while (row + 1 != inputMtrx.GetLength(0) && inputMtrx[row + 1, col] != ">" &&
                                                        inputMtrx[row + 1, col] != "<" &&
                                                        inputMtrx[row + 1, col] != "v" &&
                                                        inputMtrx[row + 1, col] != "^")
            {
                inputMtrx[row + 1, col] = " ";
                row++;
            }
        }
        static void CommandUp(string[,] inputMtrx, int row, int col)
        {
            while (row - 1 != -1 && inputMtrx[row - 1, col] != ">" &&
                                    inputMtrx[row - 1, col] != "<" &&
                                    inputMtrx[row - 1, col] != "v" &&
                                    inputMtrx[row - 1, col] != "^")
            {
                inputMtrx[row - 1, col] = " ";
                row--;
            }
        }
        static void CommandLeft(string[,] inputMtrx, int row, int col)
        {
            while (col - 1 != -1 && inputMtrx[row, col - 1] != ">" &&
                                    inputMtrx[row, col - 1] != "<" &&
                                    inputMtrx[row, col - 1] != "v" &&
                                    inputMtrx[row, col - 1] != "^")
            {
                inputMtrx[row, col - 1] = " ";
                col--;
            }
        }
        static void PrintMatrix(string[,] inputMtrx)
        {
            for (int row = 0; row < inputMtrx.GetLength(0); row++)
            {
                Console.Write("<p>");
                for (int col = 0; col < inputMtrx.GetLength(1); col++)
                {
                    if (inputMtrx[row, col] == ">")
                    {
                        inputMtrx[row, col] = escapedRight;
                    }
                    if (inputMtrx[row, col] == "<")
                    {
                        inputMtrx[row, col] = escapedLeft;
                    }
                    Console.Write(inputMtrx[row, col]);
                }
                Console.WriteLine("</p>");
            }
        }
    }
}
