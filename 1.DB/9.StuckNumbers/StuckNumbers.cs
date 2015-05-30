//This problem is from the Java Basics Exam (1 June 2014). 
//https://judge.softuni.bg/Contests/Practice/Index/14#0

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class StuckNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string[] inputNumbers = Console.ReadLine().Split(new char[] { ' ' }, 
            StringSplitOptions.RemoveEmptyEntries);
        if (n > 50 || n < 1)
        {
            return;
        }
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            if (int.Parse(inputNumbers[i]) > 9999 || int.Parse(inputNumbers[i]) < 0)
            {
                return;
            }
        }
        StringBuilder combinations = new StringBuilder();
        for (int i = 0; i < inputNumbers.Length; i++)
        {
            for (int j = i + 1; j < inputNumbers.Length; j++)
            {
                combinations.Append(inputNumbers[i] + inputNumbers[j] + " " + i + "/" + j + " ");
            }
        }
        for (int i = inputNumbers.Length - 1; i > 0 ; i--)
        {
            for (int j = i - 1; j >= 0 ; j--)
            {
                combinations.Append(inputNumbers[i] + inputNumbers[j] + " " + i + "/" + j + " ");
            }
        }
        string[] combsInd = combinations.ToString().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] combsNums = new int[combsInd.Length / 2];
        for (int i = 0; i < combsInd.Length; i = i + 2)
        {
            combsNums[i / 2] = int.Parse(combsInd[i]);
        }
        bool stuckNums = false;
        for (int i = 0; i < combsNums.Length; i++)
        {
            for (int j = i + 1; j < combsNums.Length; j++)
            {
                if (combsNums[i] == combsNums[j])
                {
                    stuckNums = true;
                    string[] firstIndexes = combsInd[i * 2 + 1].Split('/');
                    string[] secondIndexes = combsInd[j * 2 + 1].Split('/');
                    if (inputNumbers[int.Parse(firstIndexes[0])] != inputNumbers[int.Parse(firstIndexes[1])] &&
                        inputNumbers[int.Parse(firstIndexes[0])] != inputNumbers[int.Parse(secondIndexes[0])] &&
                        inputNumbers[int.Parse(firstIndexes[0])] != inputNumbers[int.Parse(secondIndexes[1])] &&
                        inputNumbers[int.Parse(firstIndexes[1])] != inputNumbers[int.Parse(secondIndexes[0])] &&
                        inputNumbers[int.Parse(firstIndexes[1])] != inputNumbers[int.Parse(secondIndexes[1])] &&
                        inputNumbers[int.Parse(secondIndexes[0])] != inputNumbers[int.Parse(secondIndexes[1])])
                    {
                        Console.WriteLine("{0}|{1}=={2}|{3}", inputNumbers[int.Parse(firstIndexes[0])],
                                                               inputNumbers[int.Parse(firstIndexes[1])],
                                                               inputNumbers[int.Parse(secondIndexes[0])],
                                                               inputNumbers[int.Parse(secondIndexes[1])]);
                        Console.WriteLine("{2}|{3}=={0}|{1}", inputNumbers[int.Parse(firstIndexes[0])],
                                                               inputNumbers[int.Parse(firstIndexes[1])],
                                                               inputNumbers[int.Parse(secondIndexes[0])],
                                                               inputNumbers[int.Parse(secondIndexes[1])]);
                    }
                    else
                    {
                        stuckNums = false;
                    }
                }
            }
        }
        if (stuckNums == false)
        {
            Console.WriteLine("No");
        }
    }
}