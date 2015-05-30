//Write a program to read an array of numbers from the console, sort them and print them back on the console. 
//The numbers should be entered from the console on a single line, separated by a space. 

using System;
using System.Collections.Generic;
using System.Linq;

class SortArray
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[inputArr.Length];
        for (int index = 0; index < inputArr.Length; index++)
        {
            numbers[index] = Int32.Parse(inputArr[index]);
        }
        Array.Sort(numbers);
        Console.WriteLine(string.Join(" ", numbers));
    }
}