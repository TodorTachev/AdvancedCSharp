//Write a program that reads a keyword and some text from the console and prints all sentences from the text, containing that word. 
//A sentence is any sequence of words ending with '.', '!' or '?'. 

using System;
using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string keyword = Console.ReadLine();
            string text = Console.ReadLine();
            string pattern = @"[^\s][\w\s]+" + keyword + @"[\w\s]+[\.?!]";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(text);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }