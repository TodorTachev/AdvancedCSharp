//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"(.)\1+";
        string result = Regex.Replace(input, pattern, @"$1");
        Console.WriteLine(result);
    }
}