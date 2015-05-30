//Write a method that reverses the digits of a given floating-point number.

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

class ReverseNumber
{
    static void Main()
    {
        double a = Double.Parse(Console.ReadLine());
        Console.WriteLine(ReverseDigits(a));
    }

    static string ReverseDigits(double number)
    {
        char[] resultArr = number.ToString().ToCharArray().Reverse().ToArray();
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < resultArr.Length; i++)
        {
            result.Append(resultArr[i]);
        }
        return result.ToString();
    }
}