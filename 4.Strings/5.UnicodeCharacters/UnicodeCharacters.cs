//Write a program that converts a string to a sequence of C# Unicode character literals.

using System;

class UnicodeCharacters

{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] inputArr = input.ToCharArray();
        foreach (var letter in inputArr)
        {
            Console.Write("\\u" + "{0:X4}", Convert.ToInt32(letter));
        }
        Console.WriteLine();
    }
}
