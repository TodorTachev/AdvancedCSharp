//This problem is originally from the JavaScript Basics Exam (22 November 2014).
//https://judge.softuni.bg/Contests/Practice/Index/84#3

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class QueryMess
{
    static void Main()
    {
        StringBuilder input = new StringBuilder();
        while (true)
        {
            string line = Console.ReadLine();
            if (line == "END")
            {
                break;
            }
            else
            {
                input.Append(line + "\n");
            }
        }
        input.Replace('?', '&');
        input.Replace("\n", "&\n&");
        input.Insert(0, '&');

        string spacePattern1 = @"%20|\+";
        string spacePattern2 = @"\s{2,}";
        string inputStr = Regex.Replace(input.ToString(), spacePattern1, " ");
        inputStr = Regex.Replace(inputStr, spacePattern2, " ");

        string linePattern = @"(?<=^|\n)(.*)(?=\n)";
        Regex lineRgx = new Regex(linePattern);
        MatchCollection lines = lineRgx.Matches(inputStr);

        string pairPattern = @"(?<=\&)(.*?)(?=\&)";
        Regex pairRgx = new Regex(pairPattern);
        MatchCollection pairs;

        string fieldPattern = @"(?<field>(.*?))(?=\=|\s)";
        Regex fieldRgx = new Regex(fieldPattern);
        Match field;

        string valuePattern = @"(?<=\=)(?<value>(.*))";
        Regex valueRgx = new Regex(valuePattern);
        Match value;

        string spacePattern3 = @"^\s|\s$";
        string fieldStr;
        string valueStr;
        Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();
        
        foreach (var line in lines)
        {
            output.Clear();
            pairs = pairRgx.Matches(line.ToString());
            foreach (var pair in pairs)
            {
                field = fieldRgx.Match(pair.ToString());
                value = valueRgx.Match(pair.ToString());
                if ((field.Groups["field"].ToString() != "") && (value.Groups["value"].ToString() != ""))
                {
                    fieldStr = Regex.Replace(field.Groups["field"].ToString(), spacePattern3, "");
                    valueStr = Regex.Replace(value.Groups["value"].ToString(), spacePattern3, "");
                    if (output.ContainsKey(fieldStr))
                    {
                        output[fieldStr].Add(valueStr);
                    }
                    else
                    {
                        output.Add(fieldStr, new List<string>());
                        output[fieldStr].Add(valueStr);
                    }
                }
            }
            foreach (var pair in output)
            {
                Console.Write("{0}=[{1}]", pair.Key, String.Join(", ", pair.Value));
            }
            Console.WriteLine();
        }
    }
}