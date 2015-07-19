using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActivityTracker
{
    class Program
    {
        static void Main()
        {
            //var tracker = new Dictionary<int, Dictionary<string, ulong>>();
            //int numberOfInputLines = int.Parse(Console.ReadLine());
            //for (int line = 0; line < numberOfInputLines; line++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');
            //    int month  = int.Parse(input[0].Split('/')[1]);
            //    string name = input[1];
            //    uint distance = uint.Parse(input[2]);

            //    if (!tracker.ContainsKey(month))
            //    {
            //        tracker[month] = new Dictionary<string, ulong>();
            //        tracker[month].Add(name, distance);
            //    }
            //    else
            //    {
            //        if (!tracker[month].ContainsKey(name))
            //        {
            //            tracker[month].Add(name, distance);
            //        }
            //        else
            //        {
            //            tracker[month][name] += distance;
            //        }
            //    }
            //}

            //var sortedTrackerByMonths = tracker.OrderBy(tr => tr.Key);

            //foreach (var month in sortedTrackerByMonths)
            //{
            //    var sortedTrackerByDistances = tracker[month.Key].OrderByDescending(d => d.Value);
            //    var namesWithDistance = new List<string>();
            //    foreach (var name in sortedTrackerByDistances)
            //    {
            //        namesWithDistance.Add(string.Format("{0}({1})", name.Key, name.Value));
            //    }
            //    Console.WriteLine("{0}: {1}", month.Key, string.Join(", ", namesWithDistance));
            //}

            var tracker = new Dictionary<int, List<User>>();
            int numberOfInputLines = int.Parse(Console.ReadLine());
            for (int line = 0; line < numberOfInputLines; line++)
            {
                string[] input = Console.ReadLine().Split(' ');
                int month = int.Parse(input[0].Split('/')[1]);
                string name = input[1];
                int distance = int.Parse(input[2]);

                if (!tracker.ContainsKey(month))
                {
                    tracker[month] = new List<User>();
                    tracker[month].Add(new User(name, distance));
                }
                else
                {
                    var user = tracker[month].FirstOrDefault(u => u.Name == name);
                    if (user == null)
                    {
                        tracker[month].Add(new User(name, distance));
                    }
                    else
                    {
                        user.Distance += distance;
                    }
                }
            }

            var sortedTrackerByMonths = tracker.OrderBy(tr => tr.Key);

            foreach (var month in sortedTrackerByMonths)
            {
                var sortedUsersByDistances = month.Value.OrderByDescending(u => u.Distance);
                var namesWithDistance = new List<string>();
                foreach (var user in sortedUsersByDistances)
                {
                    namesWithDistance.Add(string.Format("{0}({1})", user.Name, user.Distance));
                }
                Console.WriteLine("{0}: {1}", month.Key, string.Join(", ", namesWithDistance));
            }
        }
    }

    class User
    {
        public User(string name, int distance)
        {
            this.Name = name;
            this.Distance = distance;
        }

        public string Name { get; set; }

        public int Distance { get; set; } 
    }
}
