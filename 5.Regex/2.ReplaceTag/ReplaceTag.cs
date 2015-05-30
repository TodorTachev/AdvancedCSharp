//Write a program that replaces in a HTML document given as string all the tags <a href=…>…</a> with corresponding tags [URL href=…]…[/URL].
//Print the result on the console.

using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"[<a>]";
        Regex regex = new Regex(pattern);
        string result = regex.Replace(input, new MatchEvaluator(ReplaceChar));
        Console.WriteLine(result);
    }

    static string ReplaceChar(Match match)
    {
        StringBuilder m = new StringBuilder(match.ToString());
        m.Replace('<', '[');
        m.Replace('>', ']');
        m.Replace("a", "URL");
        string result = m.ToString();
        return result;
    }
}