using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyramid
{
    class Pyramid
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<int> sequence = new List<int>();
            int previousNumber = 0; ;
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] row = input.Select(number => int.Parse(number)).ToArray();
                Array.Sort(row);
                if (i == 0)
                {
                    sequence.Add(row[i]);
                    previousNumber = row[i];
                }
                else
                {
                    bool hasChanged = false;
                    for (int index = 0; index < row.Length; index++)
                    {
                        if (row[index] > previousNumber)
                        {
                            sequence.Add(row[index]);
                            previousNumber = row[index];
                            hasChanged = true;
                            break;
                        }
                    }
                    if (!hasChanged)
                    {
                        previousNumber++;
                    }
                }
            }
            Console.WriteLine(String.Join(", ", sequence));
        }
    }
}
