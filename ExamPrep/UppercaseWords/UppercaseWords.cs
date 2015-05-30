using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Security;

namespace UppercaseWords
{
    class UppercaseWords
    {
        static void Main()
        {
            StringBuilder text = new StringBuilder();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                text.AppendLine(input);
            }
            string upperCaseWordsPattern = @"(?<![a-zA-Z])[A-Z]+(?![a-zA-Z])";
            Regex upperCaseRgx = new Regex(upperCaseWordsPattern);
            string result = upperCaseRgx.Replace(text.ToString(), new MatchEvaluator(ReplaceMatch));
            text.Clear();
            text.Append(result);
            string escapedCharLeft = SecurityElement.Escape(@"<");
            string escapedCharRight = SecurityElement.Escape(@">");
            text.Replace(">", escapedCharRight);
            text.Replace("<", escapedCharLeft);
            Console.WriteLine(text);
        }
        static string ReplaceMatch(Match match)
        {
            string word = match.ToString();
            string wordReversed = ReverseString(word);
            if (word == wordReversed)
            {
                return DoubleTheLetters(word);
            }
            return wordReversed;
        }
        static string DoubleTheLetters(string word)
        {
            char[] arr = word.ToCharArray();
            char[] result = new char[arr.Length * 2];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = arr[i / 2];
            }
            return new String(result);
        }
        static string ReverseString(string word)
        {
            char[] wordArr = word.ToCharArray();
            Array.Reverse(wordArr);
            return new string(wordArr);
        }
    }
}
