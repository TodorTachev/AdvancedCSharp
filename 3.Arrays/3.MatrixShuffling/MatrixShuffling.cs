//Write a program which reads a string matrix from the console and performs certain operations with its elements. 
//User input is provided like in the problem above – first you read the dimensions and then the data. 
//Your program should then receive commands in format: "swap x1 y1 x2 y2" where x1, x2, y1, y2 are coordinates in the matrix.
//In order for a command to be valid, it should start with the "swap" keyword along with four valid coordinates (no more, no less).
//You should swap the values at the given coordinates (cell [x1, y1] with cell [x2, y2]) and print the matrix at each step 
//(thus you'll be able to check if the operation was performed correctly). 
//If the command is not valid (doesn't contain the keyword "swap", has fewer or more coordinates entered or the given coordinates do not exist), 
//print "Invalid input!" and move on to the next command. Your program should finish when the string "END" is entered. 

using System;
using System.Text.RegularExpressions;

class MatrixShuffling
{
    static int firstDimention;
    static int secondDimention;
    static string[,] matrix;
    static string[] command;

    static void Main()
    {
        Input();
    }

    static void Input()
    {
        firstDimention = int.Parse(Console.ReadLine());
        secondDimention = int.Parse(Console.ReadLine());
        matrix = new string[firstDimention, secondDimention];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = Console.ReadLine();
            }
        }

        Regex rgx = new Regex(@"^swap\s[0-9]\s[0-9]\s[0-9]\s[0-9]$");
        string commandInput;
        string temp;

        while (true)
        {
            Console.WriteLine("Enter command");
            commandInput = Console.ReadLine();
            if (commandInput == "END")
            {
                return;
            }
            command = commandInput.Split(' ');
            if (rgx.IsMatch(commandInput) == false || ProcessCommand(command) == false)
            {
                Console.WriteLine("Invalid input!");
            }
            else
            {
                temp = matrix[int.Parse(command[1]), int.Parse(command[2])];
                matrix[int.Parse(command[1]), int.Parse(command[2])] = matrix[int.Parse(command[3]), int.Parse(command[4])];
                matrix[int.Parse(command[3]), int.Parse(command[4])] = temp;
                PrintMatrix(matrix);
            }
        }
    }
    static bool ProcessCommand(string[] command)
    {
        int number;
        if (command.Length != 5)
        {
            return false;
        }
        if (command[0] != "swap")
        {
            return false;
        }
        for (int index = 1; index < command.Length; index++)
        {
            int.TryParse(command[index], out number);
            if (!int.TryParse(command[index], out number))
            {
                return false;
            }
            if (index % 2 == 0 && (number > secondDimention - 1 || number < 0))
            {
                return false;
            }
            if (index % 2 != 0 && (number > firstDimention - 1 || number < 0))
            {
                return false;
            }
            if (!int.TryParse(command[index], out number))
            {
                return false;
            }
        }
        return true;
    }

    static void PrintMatrix(string[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0, 3}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}