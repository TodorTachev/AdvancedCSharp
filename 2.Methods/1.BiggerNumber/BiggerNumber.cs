//Write a method GetMax() with two parameters that returns the larger of two integers. 
//Write a program that reads 2 integers from the console and prints the largest of them using the method GetMax()

using System;

class BiggerNumber
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine(GetMax(a, b));
    }

    static int GetMax(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}