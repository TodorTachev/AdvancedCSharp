using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountSymbols
{
    static void Main()
    {
        char[] input = Console.ReadLine().ToCharArray();
        Dictionary<char, int> result = new Dictionary<char, int>();
        for (int index = 0; index < input.Length; index++)
        {
            int count = input.Count(character => character == input[index]);
            result[input[index]] = count;
        }
        var sortedResult = result.OrderBy(character => character.Key);
        foreach (var pair in sortedResult)
        {
            Console.WriteLine("{0}: {1} time(s)", pair.Key, pair.Value);
        }
    }
}