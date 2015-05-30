//Write methods to calculate the minimum, maximum, average, sum and product of a given set of numbers. 
//Overload the methods to work with numbers of type double and decimal.
//Note: Do not use LINQ.

using System;

class NumberCalculations
{
    static void Main()
    {
        Console.WriteLine("Choose data type.");
        Console.WriteLine("1 - integer");
        Console.WriteLine("2 - double");
        Console.WriteLine("3 - decimal");
        int dataType = int.Parse(Console.ReadLine());
        Console.Write("Enter the numbers:");
        string[] input = Console.ReadLine().Split(' ');
        switch (dataType)
        {
            case 1:
                {
                    int[] numbers = new int[input.Length];
                    for (int i = 0; i < input.Length; i++)
                    {
                        numbers[i] = int.Parse(input[i]);
                    }
                    Console.Write("Min:");
                    Console.WriteLine(GetMin(numbers));
                    Console.Write("Max:");
                    Console.WriteLine(GetMax(numbers));
                    Console.Write("Average:");
                    Console.WriteLine(GetAverage(numbers));
                    Console.Write("Sum:");
                    Console.WriteLine(GetSum(numbers));
                    break;
                }
            case 2:
                {
                    double[] numbers = new double[input.Length];
                    for (int i = 0; i < input.Length; i++)
                    {
                        numbers[i] = double.Parse(input[i]);
                    }
                    Console.Write("Min:");
                    Console.WriteLine(GetMin(numbers));
                    Console.Write("Max:");
                    Console.WriteLine(GetMax(numbers));
                    Console.Write("Average:");
                    Console.WriteLine(GetAverage(numbers));
                    Console.Write("Sum:");
                    Console.WriteLine(GetSum(numbers));
                    break;
                }
            case 3:
            {
                decimal[] numbers = new decimal[input.Length];
                for (int i = 0; i < input.Length; i++)
                {
                    numbers[i] = decimal.Parse(input[i]);
                }
                Console.Write("Min:");
                Console.WriteLine(GetMin(numbers));
                Console.Write("Max:");
                Console.WriteLine(GetMax(numbers));
                Console.Write("Average:");
                Console.WriteLine(GetAverage(numbers));
                Console.Write("Sum:");
                Console.WriteLine(GetSum(numbers));
                break;
            }
            default:
                break;
        }
    }
    //
    //GetMin() Methods
    //
    static int GetMin(int[] numbers)
    {
        int min = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
		{
			 if (numbers[i] < min)
             {
                 min = numbers[i];
             }
		}
        return min;
    }
    static double GetMin(double[] numbers)
    {
        double min = double.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    static decimal GetMin(decimal[] numbers)
    {
        decimal min = decimal.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }
        return min;
    }
    //
    //GetMax() Methods
    //
    static int GetMax(int[] numbers)
    {
        int max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    static double GetMax(double[] numbers)
    {
        double max = double.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    static decimal GetMax(decimal[] numbers)
    {
        decimal max = decimal.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }
        return max;
    }
    //
    //GetAverage() Methods
    //
    static double GetAverage(int[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum / numbers.Length;
    }
    static double GetAverage(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum / numbers.Length;
    }
    static decimal GetAverage(decimal[] numbers)
    {
        decimal sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum / numbers.Length;
    }
    //
    //GetSum() Methods
    //
    static int GetSum(int[] numbers)
    {
        int sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static double GetSum(double[] numbers)
    {
        double sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
    static decimal GetSum(decimal[] numbers)
    {
        decimal sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }
        return sum;
    }
}