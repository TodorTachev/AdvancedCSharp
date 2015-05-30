//Write a method that returns the index of the first element in array that is larger than its neighbours,
//or -1 if there's no such element.

using System;
using System.Linq;

class FirstLargerThanNeighbours
{
    static void Main()
    {
        int[] inputArr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Console.WriteLine(GetIndexIfLargerThanNeighbours(inputArr));
    }

    static int GetIndexIfLargerThanNeighbours(int[] arr)
    {
        for (int index = 0; index < arr.Length; index++)
        {
            if (index == 0)
            {
                if (arr[index] > arr[index + 1])
                {
                    return index;
                }
            }
            else if (index == arr.GetUpperBound(0))
            {
                if (arr[index] > arr[index - 1])
                {
                    return index;
                }
            }
            else
            {
                if (arr[index] > arr[index - 1] && arr[index] > arr[index + 1])
                {
                    return index;
                }

            }
        }
        return -1;
    }
}