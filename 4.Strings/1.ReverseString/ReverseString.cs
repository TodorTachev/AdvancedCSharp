//Write a program that reads a string from the console, reverses it and prints the result back at the console.

using System;
using System.Linq;

class ReverseString
{
    static void Main()
    {
        string input = Console.ReadLine();
        char[] inputArr = input.ToCharArray();
        Array.Reverse(inputArr);
        string result = new string(inputArr);
        Console.WriteLine(result);
    }
}

