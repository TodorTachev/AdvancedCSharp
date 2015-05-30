using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class TerroristsWin
{
    static void Main()
    {
        string input = Console.ReadLine();
        if (input.Length > 1000 || input.Length < 1)
        {
            return;
        }
        char[] inputArr = input.ToCharArray();
        int startingSearchPosition = 0;
        int firstPipePosition;
        int secondPipePosition;
        int startIndex;
        int endIndex = -1;
        Regex rgx = new Regex(@"\|(.*?)\|");
        MatchCollection matches = rgx.Matches(input);
        foreach (Match match in matches)
        {
            int sum = 0;
            char[] bomb = match.Groups[1].ToString().ToCharArray();
            if (bomb.Length > 100)
            {
                return;
            }
            for (int index = 0; index < bomb.Length; index++)
            {
                sum += (byte)bomb[index];
            }
            int bombPower = sum % 10;
            firstPipePosition = input.IndexOf('|', startingSearchPosition);
            startingSearchPosition = firstPipePosition + 1;
            secondPipePosition = input.IndexOf('|', startingSearchPosition);
            startingSearchPosition = secondPipePosition + 1;
            startIndex = firstPipePosition - bombPower;
            if (startIndex < 0)
            {
                startIndex = 0;
            }
            if (startIndex <= endIndex)
            {
                return;
            }
            endIndex = secondPipePosition + bombPower;
            if (endIndex > inputArr.Length - 1)
            {
                endIndex = inputArr.Length - 1;
            }
            for (int index = startIndex; index <= endIndex; index++)
			{
                inputArr[index] = '.';
			}
        }
        string result = new String(inputArr);
        Console.WriteLine(result);
    }
}