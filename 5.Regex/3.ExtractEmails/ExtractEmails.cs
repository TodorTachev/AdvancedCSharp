//Write a program to extract all email addresses from a given text. 
//The text comes at the only input line. 
//Print the emails on the console, each at a separate line. 

using System;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"[^\.\-_\s][\w\.\-]+@{1}([A-Za-z]+[\.\-]+)+[A-Za-z]+";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(input);
        foreach (var match in matches)
        {
            Console.WriteLine(match);
        }
    }
}