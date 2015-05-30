//Write a program that reads from the console a number N and an array of integers given on a single line. 
//Your task is to find all subsets within the array which have a sum equal to N and print them on the console 
//(the order of printing is not important). Find only the unique subsets by filtering out repeating numbers first. 
//In case there aren't any subsets with the desired sum, print "No matching subsets." 

using System;
using System.Collections.Generic;
using System.Linq;

class SubsetSums
{
    static int sum;
    static bool subsetFound = false;
    static int[] numbers;
    //static List<List<int>> subsets = new List<List<int>>(); //K.M.
    static List<int[]> subsets = new List<int[]>();

    static void Main()
    {
        sum = int.Parse(Console.ReadLine());
        numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();
        //List<int> subset = new List<int>();
        //MakeSubset(0, subset);    //K.M.

        subsets = Enumerable
              .Range(0, (int)Math.Pow(2, (numbers.Length)))
              .Select(num => numbers.Where((x, i) => ((1 << i) & num) > 0).ToArray())
              .ToList();
        //http://stackoverflow.com/questions/13793583/find-all-subsets-with-enumerable-zip-or-bitwise-and-logic
        
        PrintSubset();
        if (subsetFound == false)
        {
            Console.WriteLine("No matching subsets.");
        }
    }

    static void PrintSubset()
    {
        foreach (var item in subsets)
        {
            if (item.Sum() == sum)
            {
                Console.WriteLine(String.Join(" + ", item) + " = " + sum);
                subsetFound = true;
            }
        }
    }

    //static void MakeSubset(int index, List<int> subset)
    //{
    //    if (subset.Sum() == sum && subset.Count > 0)
    //    {
    //        subsets.Add(new List<int>(subset));
    //        subsetFound = true; 
    //    }                                                             //K.M.

    //    for (int i = index; i < numbers.Length; i++)
    //    {
    //        subset.Add(numbers[i]);
    //        MakeSubset(i + 1, subset);
    //        subset.RemoveAt(subset.Count - 1);
    //    }
    //}
    //https://github.com/KatyaMarincheva/SoftUni/blob/master/SoftUni-Homeworks/Advanced%20C%23/01.%20Arrays-Lists-Stacks-Queues-Homework/07.%20Sorted-Subset-Sums/SortedSubsetSums.cs
}