using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TheNumbers
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string antinumPattern = @"[^\d]";
            Regex antinumRegex = new Regex(antinumPattern);
            string numbers = antinumRegex.Replace(input, " ");
            string[] numArr = numbers.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<string> output = new List<string>();
            foreach (var number in numArr)
            {
                output.Add(string.Format("0x{0:X4}", (Convert.ToInt32(number))));
            }
            Console.WriteLine(string.Join("-", output));
        }
    }
}
