using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PlusRemove
{
    static void Main()
    {
        List<string[]> inputList = new List<string[]>();
        Dictionary<int, List<int>> indexes = new Dictionary<int, List<int>>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            string[] inputArr = input.Select(ch => ch.ToString()).ToArray();
            inputList.Add(inputArr);
        }
        string[][] plusContaner = new string[inputList.Count][];
        for (int index = 0; index < plusContaner.Length; index++)
        {
            plusContaner[index] = inputList[index];
        }
        for (int row = 1; row < plusContaner.Length - 1; row++)
        {
            for (int col = 1; col < plusContaner[row].Length - 1; col++)
            {
                if (col >= plusContaner[row - 1].Length ||
                    col >= plusContaner[row + 1].Length)
                {
                    break;
                }
                if (String.Compare(plusContaner[row][col], plusContaner[row - 1][col], true) == 0 &&
                    String.Compare(plusContaner[row][col], plusContaner[row + 1][col], true) == 0 &&
                    String.Compare(plusContaner[row][col], plusContaner[row][col + 1], true) == 0 &&
                    String.Compare(plusContaner[row][col], plusContaner[row][col - 1], true) == 0)
                {
                    if (indexes.ContainsKey(row))
                    {
                        indexes[row].Add(col);
                    }
                    else
                    {
                        indexes[row] = new List<int> { col };
                    }
                }
            }
        }
        foreach (var pair in indexes)
	    {
            int row = pair.Key;
            List<int> colList = indexes[row];
		    for (int i = 0; i < colList.Count; i++)
			{
                plusContaner[row][colList[i]] = "";
                plusContaner[row - 1][colList[i]] = "";
                plusContaner[row + 1][colList[i]] = "";
                plusContaner[row][colList[i] + 1] = "";
                plusContaner[row][colList[i] - 1] = "";
			}
	    }
        for (int row = 0; row < plusContaner.Length; row++)
        {
            for (int col = 0; col < plusContaner[row].Length; col++)
            {
                Console.Write(plusContaner[row][col]);
            }
            Console.WriteLine();
        }
    }
}