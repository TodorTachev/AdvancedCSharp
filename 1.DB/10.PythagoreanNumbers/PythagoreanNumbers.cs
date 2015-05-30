//This problem is from the Java Basics Exam (26 May 2014). 
//https://judge.softuni.bg/Contests/Practice/Index/12#1

using System;

class PythagoreanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        if (n < 1 || n > 100)
        {
            return;
        }
        int[] numbers = new int[n];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
            if (numbers[i] > 999 || numbers[i] < 0)
            {
                return;
            }
        }
        Array.Sort(numbers);
        bool pytNums = false;
        for (int a = 0; a < numbers.Length; a++)
        {
            for (int b = 0; b < numbers.Length; b++)
            {
                for (int c = 0; c < numbers.Length; c++)
                {
                    if (numbers[a]*numbers[a] + numbers[b]*numbers[b] == numbers[c]*numbers[c] && a <= b)
                    {
                        pytNums = true;
                        Console.WriteLine("{0}*{0} + {1}*{1} = {2}*{2}", numbers[a], numbers[b], numbers[c]);
                    }
                }
            }
        }
        if (pytNums == false)
        {
            Console.WriteLine("No");
        }
    }
}