//Write a program that reads N floating-point numbers from the console. 
//Your task is to separate them in two sets, one containing only the round numbers (e.g. 1, 1.00, etc.) 
//and the other containing the floating-point numbers with non-zero fraction. 
//Print both arrays along with their minimum, maximum, sum and average (rounded to two decimal places)

using System;
using System.Collections.Generic;
using System.Linq;

class CategorizeNumbers 
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        List<int> integers = new List<int>();
        List<double> doubles = new List<double>();
        double temp;
        for (int index = 0; index < inputArr.Length; index++)
        {
            if (Double.Parse(inputArr[index]) == (int)Double.Parse(inputArr[index]))
            {
                temp = Double.Parse(inputArr[index]);
                integers.Add((int)temp);
            }
            else
            {
                doubles.Add(double.Parse(inputArr[index]));
            }
        }
        Console.WriteLine("[{0}] -> min: {1}, max {2}, sum: {3}, avg: {4:0.00}",
            string.Join(", ", integers), integers.Min(), integers.Max(), integers.Sum(), integers.Average());
        Console.WriteLine("[{0:0.00}] -> min: {1:0.00}, max {2:0.00}, sum: {3:0.00}, avg: {4:0.00}",
            string.Join(", ", doubles), doubles.Min(), doubles.Max(), doubles.Sum(), doubles.Average());
    }
}