//Write a program to find all increasing sequences inside an array of integers. 
//The integers are given on a single line, separated by a space. 
//Print the sequences in the order of their appearance in the input array, each at a single line. 
//Separate the sequence elements by a space. 
//Find also the longest increasing sequence and print it at the last line. 
//If several sequences have the same longest length, print the left-most of them

using System;

class LongestIncreasingSequence
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[inputArr.Length];

        for (int index = 0; index < numbers.Length; index++)
        {
            numbers[index] = Int32.Parse(inputArr[index]);
        }
        int counter = 0;
        int bestCounter = counter;
        int lastIndex = 0;

        for (int index = 0; index < numbers.Length; index++)
        {
            if (index == 0)
            {
                if (numbers[index] < numbers[index + 1])
                {
                    Console.Write(numbers[index] + " ");
                    counter++;
                }
                else
                {
                    Console.WriteLine(numbers[index]);
                    counter++;
                }
            }
            else
            {
                if (numbers[index] > numbers[index - 1])
                {
                    Console.Write(numbers[index] + " ");
                    counter++;
                }
                else
                {
                    Console.Write("\n" + numbers[index] + " ");
                    if (counter > bestCounter)
                    {
                        bestCounter = counter;
                        lastIndex = index - 1;
                    }
                    counter = 0;
                }
            }
        }
        Console.WriteLine();
        Console.Write("Longest: ");
        for (int i = lastIndex - counter; i <= lastIndex; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}