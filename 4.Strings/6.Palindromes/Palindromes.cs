//Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe and prints them on the console on a single line, separated by comma and space. 
//Use spaces, commas, dots, question marks and exclamation marks as word delimiters. 
//Print only unique palindromes, sorted lexicographically.

using System;
using System.Linq;
using System.Collections.Generic;

class Palindromes
{
    static void Main()
    {
        string input = Console.ReadLine();
        string[] inputArr = input.Split(new string[] { ",", " ", ".", "!", "?" }, StringSplitOptions.RemoveEmptyEntries);
        List<string> palindromes = new List<string>();

        for (int index = 0; index < inputArr.Length; index++)
        {
            if (inputArr[index].Length > 1)
            {
                if (string.Compare(inputArr[index], new string(inputArr[index].ToCharArray().Reverse().ToArray()), true) == 0)
                {
                    palindromes.Add(inputArr[index]);
                }
            }
        }

        //If casing matters for the uniqueness add next line:
        //palindromes = palindromes.ConvertAll(d => d.ToLower());

        List<string> unique = palindromes.Distinct().ToList();
        unique.Sort();

        for (int index = 0; index < unique.Count; index++)
        {
            if(index != unique.Count - 1)
            {
                Console.Write(unique[index] + ", ");
            }
            else
            {
                Console.WriteLine(unique[index]);
            }
        }
    }
}