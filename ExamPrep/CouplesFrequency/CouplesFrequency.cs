using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CouplesFrequency
{
    class CouplesFrequency
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(' ');
            int[] numbers = input.Select(number => int.Parse(number)).ToArray();
            Dictionary<string, int> result = new Dictionary<string, int>();
            double couplesCount = 0;
            for (int i = 0, j = i + 1; j < numbers.Length; i++, j++)
            {
                string couple = String.Format("{0} {1}", numbers[i], numbers[j]);
                couplesCount++;
                if (result.ContainsKey(couple))
                {
                    result[couple]++;
                }
                else
                {
                    result[couple] = 1;
                }
            }
            foreach (var pair in result)
            {
                Console.WriteLine("{0} -> {1:0.00}%", pair.Key, (result[pair.Key] / couplesCount) * 100);
            }
        }
    }
}
