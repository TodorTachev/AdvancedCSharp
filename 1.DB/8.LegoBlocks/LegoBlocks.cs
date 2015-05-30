//This problem is from the Java Basics Exam (8 February 2015). 
//https://judge.softuni.bg/Contests/Practice/Index/69#2

using System;
using System.Linq;

class LegoBlocks
{
    static void Main()
    {
        int rows = int.Parse(Console.ReadLine());
        if (rows < 2 || rows > 10)
        {
            return;
        }
        int[][] firstLego = new int[rows][];
        int[][] secondLego = new int[rows][];
        for (int i = 0; i < 2 * rows; i++)
        {
            if (i < rows)
            {
                firstLego[i] = Console.ReadLine().Split(new char[]{' '}, 
                    StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            else
            {
                secondLego[i - rows] = Console.ReadLine().Split(new char[]{' '}, 
                    StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
        }
        int firstRowSum = firstLego[0].Length + secondLego[0].Length;
        int rowSum = 0;
        bool fit = true;
        for (int row = 1; row < rows; row++)
        {
            rowSum = firstLego[row].Length + secondLego[row].Length;
            if (rowSum != firstRowSum)
            {
                fit = false;
                break;
            }
        }
        int[][] union = new int[rows][];
        for (int row = 0; row < rows; row++)
        {
            union[row] = firstLego[row].Concat(secondLego[row].Reverse()).ToArray();
        }
        if (fit)
        {
            for (int row = 0; row < rows; row++)
            {
                Console.WriteLine("[{0}]", String.Join(", ", union[row])); 
            }
        }
        else
        {
            int counter = 0;
            for (int row = 0; row < rows; row++)
            {
                int[] innerArray = union[row];
                for (int col = 0; col < innerArray.Length; col++)
                {
                    counter++;
                }
            }
            Console.WriteLine("The total number of cells is: " + counter);
        }
    }
}