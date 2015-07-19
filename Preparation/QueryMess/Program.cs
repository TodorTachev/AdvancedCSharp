namespace QueryMess
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main()
        {
            Dictionary<string, List<string>> query = new Dictionary<string, List<string>>();
            string pattern = @"\s+";
            Regex regex = new Regex(pattern);

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                query.Clear();
                input = input.Replace('+', ' ');
                input = input.Replace("%20", " ");
                input = regex.Replace(input, " ");
                string[] inputArr = input.Split('?');

                foreach (var pair in inputArr)
                {
                    if (pair.Contains("="))
                    {
                        string[] keysAndValues = pair.Split('&');
                        foreach (var keyVal in keysAndValues)
                        {
                            string[] keyValue = keyVal.Split('=');
                            if (query.ContainsKey(keyValue[0].Trim()))
                            {
                                query[keyValue[0].Trim()].Add(keyValue[1].Trim());
                            }
                            else
                            {
                                query[keyValue[0].Trim()] = new List<string>();
                                query[keyValue[0].Trim()].Add(keyValue[1].Trim());
                            }
                        }
                    }
                }

                foreach (var key in query.Keys)
                {
                    Console.Write(key + "=[" + string.Join(", ", query[key]) + "]");
                }
                Console.WriteLine();
            }
        }
    }
}
