//Write a program that takes a text and a string of banned words. 
//All words included in the ban list should be replaced with asterisks "*", equal to the word's length.
//The entries in the ban list will be separated by a comma and space ", ".
//The ban list should be entered on the first input line and the text on the second input line. 

using System;
using System.Text;

class TextFilter
{
    static void Main()
    {
        string banList = Console.ReadLine();
        string inputText = Console.ReadLine();

        string[] banWords = banList.Split(new string[] { ", " }, StringSplitOptions.None);
        StringBuilder text = new StringBuilder(inputText);

        for (int index = 0; index < banWords.Length; index++)
        {
            text.Replace(banWords[index], new string('*', banWords[index].Length));
        }

        Console.WriteLine(text);
    }
}
