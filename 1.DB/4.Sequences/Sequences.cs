//Write a program that reads an array of strings and finds in it all sequences of equal elements 
//(comparison should be case-sensitive). 
//The input strings are given as a single line, separated by a space

using System;

class Sequences
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        for (int index = 0; index < inputArr.Length; index++)
        {
            if (index == inputArr.Length - 1)
            {
                if (String.Compare(inputArr[index], inputArr[index - 1], false) == 0)
                {
                    Console.Write(inputArr[index]);
                }
                else
                {
                    Console.WriteLine(inputArr[index]);
                }
            }
            else
            {
                if (String.Compare(inputArr[index], inputArr[index + 1], false) == 0)
                {
                    Console.Write(inputArr[index] + " ");
                }
                else
                {
                    Console.WriteLine(inputArr[index]);
                }
            }
        }
        Console.WriteLine();
    }
}