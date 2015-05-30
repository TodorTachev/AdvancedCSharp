//Write a program to find how many times a given string appears in a given text as substring. 
//The text is given at the first input line. 
//The search string is given at the second input line. 
//The output is an integer number. 
//Please ignore the character casing. Overlapping between occurrences is allowed. 

using System;

class CountSubstringOccurrences
{
    static void Main()
    {
        string text = Console.ReadLine();
        string searchString = Console.ReadLine();

        int counter = 0;
        string substring;

        if(searchString.Length <= text.Length)
        {
            for (int index = 0; index <= (text.Length - searchString.Length); index++)
            {
                substring = text.Substring(index, searchString.Length);
                if (string.Compare(searchString, substring, true) == 0)
                {
                    counter++;
                }
            }
        }
        
        Console.WriteLine(counter);
    }
}