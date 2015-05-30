//Write a method that checks if the element at given position in a given array of integers is larger than its two neighbours (when such exist).

using System;
using System.Linq;

class LargerThanNeighbours
{
    static void Main()
    {
        int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        for (int index = 0; index < inputArr.Length; index++)
        {
            Console.WriteLine(IsLargerThanNeighbours(inputArr, index));
        }
    }

    static bool IsLargerThanNeighbours(int[] arr, int position)
    {
        if (position == 0)
        {
            if (arr[position] > arr[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else if (position == arr.GetUpperBound(0))
        {
            if (arr[position] > arr[position - 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (arr[position] > arr[position - 1] && arr[position] > arr[position + 1])
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}