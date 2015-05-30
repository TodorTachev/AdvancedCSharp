using System;

class SelectionSort
{
    static void Main()
    {
        string[] inputArr = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[inputArr.Length];

        for (int index = 0; index < inputArr.Length; index++)
        {
            numbers[index] = Int32.Parse(inputArr[index]);
        }

        int max;
        int ind = -1;
        int temp;

        for (int i = 0; i < numbers.Length; i++)
        {
            max = int.MinValue;
            for (int j = i; j < numbers.Length; j++)
            {
                if (numbers[j] > max)
                {
                    max = numbers[j];
                    ind = j;
                }
            }
            temp = numbers[i];
            numbers[i] = max;
            numbers[ind] = temp;
        }

        Console.WriteLine(string.Join(" ", numbers));
    }
}