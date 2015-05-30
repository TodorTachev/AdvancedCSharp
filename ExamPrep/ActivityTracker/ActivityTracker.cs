using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Threading;

namespace ActivityTracker
{
    class ActivityTracker
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-GB");
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, Dictionary<string, int>> data = new Dictionary<int, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                DateTime date = DateTime.Parse(input[0]);
                int month = date.Month;
                string name = input[1];
                int distance = int.Parse(input[2]);
                if (!data.ContainsKey(month))
                {
                    Dictionary<string, int> person = new Dictionary<string, int>();
                    data[month] = person;
                    person[name] = distance;
                }
                else
                {
                    Dictionary<string, int> person = data[month];
                    if (!person.ContainsKey(name))
                    {
                        person[name] = distance;
                    }
                    else
                    {
                        person[name] += distance;
                    }
                }
            }
            var sortedData = data.OrderBy(m => m.Key);
            List<string> peopleList = new List<string>();
            foreach (var month in sortedData)
            {
                Console.Write("{0}: ", month.Key);
                var people = data[month.Key];
                var sortedPeople = people.OrderByDescending(distance => distance.Value);
                foreach (var person in sortedPeople)
                {
                    peopleList.Add(person.Key + "(" + person.Value + ")");
                }
                Console.WriteLine(String.Join(", ", peopleList));
                peopleList.Clear();
            }
        }
    }
}
