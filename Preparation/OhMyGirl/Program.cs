using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OhMyGirl
{
    class Program
    {
        static void Main()
        {
            string key = Console.ReadLine();
            StringBuilder input = new StringBuilder();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                input.Append(inputLine);
            }

            string keyPattern = key[0].ToString();

            for (int index = 1; index < key.Length - 1; index++)
            {
                if (char.IsDigit(key[index]))
                {
                    keyPattern += @"[0-9]*?";
                }
                else if (char.IsLower(key[index]))
                {
                    keyPattern += @"[a-z]*?";
                }
                else if (char.IsUpper(key[index]))
                {
                    keyPattern += @"[A-Z]*?";
                }
                else
                {
                    keyPattern += key[index];
                }
            }

            keyPattern += key[key.Length - 1];

            string addressPattern = @"(?:a{1}[0-9]*?#""{1}[A-Z]*?5{1})([a-zA-Z0-9,\s]{2,6})(?:a{1}[0-9]*?#""{1}[A-Z]*?5{1})";//@"(?:" + keyPattern + @")(.{2, 6}?)(?:" + keyPattern + @")";
            Regex addressRegex = new Regex(addressPattern);
            MatchCollection addressParts = addressRegex.Matches(input.ToString());
            StringBuilder address = new StringBuilder();

            foreach (Match part in addressParts)
            {
                address.Append(part.ToString());
            }

            Console.WriteLine(address);
        }
    }
}
