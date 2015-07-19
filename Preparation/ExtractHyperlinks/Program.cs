namespace ExtractHyperlinks
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "END")
                {
                    break;
                }

                input.AppendLine(inputLine);
            }

            string aTagsPattern = @"(?<=\<a)(?s).*?(?=\>)";
            string afetrHrefPattern = @"(?:href\s*={1})(?<afterHref>(?s).*?)\>";
            Regex aTagsRegex = new Regex(aTagsPattern);
            Regex afetrHrefRegex = new Regex(afetrHrefPattern);
            string text = input.ToString();

            MatchCollection matches = aTagsRegex.Matches(text);
            foreach (Match match in matches)
            {
                Match afterHref = afetrHrefRegex.Match(match.ToString());
                
                string[] result = afterHref.Groups["afterHref"].ToString().Split(' ');

                if (result[0][0] == '\'' | result[0][0] == '\"')
                {
                    Console.WriteLine(result[0].Remove(result[0].Length - 1).Remove(0, 1));
                }
                else
                {
                    Console.WriteLine(result[0]);
                }
            }
        }
    }
}
