using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            var purchases = new Dictionary<string, Dictionary<string, int>>();
            int numberOfInputLines = int.Parse(Console.ReadLine());

            for (int line = 0; line < numberOfInputLines; line++)
			{
			    string[] input = Console.ReadLine().Split(' ');
                string product = input[2];
                string customer = input[0];
                int productAmount = int.Parse(input[1]);
                if (purchases.ContainsKey(product))
                {
                    if (purchases[product].ContainsKey(customer))
                    {
                        purchases[product][customer] += productAmount;
                    }
                    else
                    {
                        purchases[product][customer] = productAmount;
                    }
                }
                else
                {
                    purchases[product] = new Dictionary<string,int>();
                    purchases[product].Add(customer, productAmount);
                }
			}

            foreach (var product in purchases.Keys)
	        {
                var sortedCustomers = purchases[product].OrderBy(c => c.Key);
                var customers = new List<string>();
                foreach (var customer in sortedCustomers)
	            {
		            customers.Add(string.Format("{0} {1}", customer.Key, customer.Value));
	            }
		        Console.WriteLine(product + ": " + string.Join(", ", customers));
	        }

        }
    }
}
