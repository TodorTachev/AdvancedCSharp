using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SumOfAllValues
{
    class Program
    {
        static void Main()
        {
            string keysString = Console.ReadLine();
            string textString = Console.ReadLine();
            string startKeyPattern = @"^[a-zA-Z_]*?(?=[0-9])";
            string endKeyPattern = @"(?<=[0-9])[a-zA-Z_]*?$";
            Regex startKeyRegex = new Regex(startKeyPattern);
            Regex endKeyRegex = new Regex(endKeyPattern);
            string startKey = startKeyRegex.Match(keysString).ToString();
            string endKey = endKeyRegex.Match(keysString).ToString();

            if (startKey != string.Empty && endKey != string.Empty)
            {
                string numbersPattern = @"(?<=" + startKey + @")[0-9\.]+?(?=" + endKey + @")";
                Regex numbersRegex = new Regex(numbersPattern);
                MatchCollection numbers = numbersRegex.Matches(textString);
                double sum = 0;
                if (numbers.Count != 0)
                {
                    foreach (Match number in numbers)
                    {
                        double num = double.Parse(number.ToString());
                        sum += num;
                    }
                }
                Console.WriteLine("<p>The total value is: <em>{0}</em></p>", sum == 0 ? "nothing" : sum.ToString());
            }
            else
            {
                Console.WriteLine("<p>A key is missing</p>");
            }
        }
    }
}
