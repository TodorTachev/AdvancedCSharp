using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BiggestTableRow
{
    class Program
    {
        static void Main(string[] args)
        {
            double maxSum = double.MinValue;
            double sum = 0;
            bool maxSumHasChanged = false;
            bool sumHasChanged = false;
            var numbersInSum = new List<string>();
            var numbersInMaxSum = new List<string>();
            string numbersPattern = @"(?<=<td>)[\-0-9\.]+(?=<\/td>)";
            var numbersRegex = new Regex(numbersPattern);

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "</table>")
                {
                    break;
                }

                MatchCollection numbers = numbersRegex.Matches(input);
                foreach (Match number in numbers)
                {
                    double num; 
                    bool isParsingSuccesful = double.TryParse(number.ToString(), out num);
                    if (isParsingSuccesful)
                    {
                        sum += num;
                        numbersInSum.Add(number.ToString());
                        sumHasChanged = true;
                    }
                }

                if (maxSum < sum && sumHasChanged)
                {
                    maxSum = sum;
                    numbersInMaxSum.Clear();
                    numbersInMaxSum.AddRange(numbersInSum);
                    maxSumHasChanged = true;
                }

                sum = 0;
                numbersInSum.Clear();
                sumHasChanged = false;
            }

            if (maxSumHasChanged)
            {
                Console.WriteLine("{0} = {1}", maxSum, string.Join(" + ", numbersInMaxSum));
            }
            else
            {
                Console.WriteLine("no data");
            }
        }
    }
}
