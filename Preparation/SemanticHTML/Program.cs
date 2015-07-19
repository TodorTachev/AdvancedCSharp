namespace SemanticHTML
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            string divOpeningTagTypePattern = @"((id=""|class="")(?<type>[a-z]+)"")";
            string divClosingTagTypePattern = @"([a-z]+)";
            string divOpeningTagPattern = @"\<div.*?\>";
            string divClosingTagPattern = @"\<\/div.*\>";

            Regex divOpeningTagTypeRegex = new Regex(divOpeningTagTypePattern);
            Regex divClosingTagTypeRegex = new Regex(divClosingTagTypePattern);
            Regex divOpeningTagRegex = new Regex(divOpeningTagPattern);
            Regex divClosingTagRegex = new Regex(divClosingTagPattern);

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                if (divOpeningTagRegex.IsMatch(inputLine))
                {
                    string divType = divOpeningTagTypeRegex.Match(inputLine).Groups["type"].ToString();
                    inputLine = divOpeningTagTypeRegex.Replace(inputLine, "");
                    inputLine = inputLine.Replace("div", divType);
                }

                Console.WriteLine(inputLine);
            }

        }
    }
}
