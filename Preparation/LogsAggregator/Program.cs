using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogsAggregator
{
    class Program
    {
        static void Main()
        {
            //var durations = new Dictionary<string, int>();
            //var ips = new Dictionary<string, List<string>>();
            //int numberOfInputLines = int.Parse(Console.ReadLine());
            //for (int line = 0; line < numberOfInputLines; line++)
            //{
            //    string[] input = Console.ReadLine().Split(' ');
            //    string user = input[1];
            //    string ip = input[0];
            //    int duration = int.Parse(input[2]);

            //    if (durations.ContainsKey(user))
            //    {
            //        durations[user] += duration;
            //    }
            //    else
            //    {
            //        durations[user] = duration;
            //    }

            //    if (ips.ContainsKey(user))
            //    {
            //        if (!ips[user].Contains(ip))
            //        {
            //            ips[user].Add(ip);
            //        }
            //    }
            //    else
            //    {
            //        ips[user] = new List<string>();
            //        ips[user].Add(ip);
            //    }
            //}
            //var sortedUsers = durations.OrderBy(user => user.Key);

            //foreach (var user in sortedUsers)
            //{
            //    ips[user.Key].Sort();
            //    Console.WriteLine("{0}: {1} [{2}]", user.Key, durations[user.Key], string.Join(", ", ips[user.Key]));
            //}

            var users = new List<User>();
            int numberOfInputLines = int.Parse(Console.ReadLine());
            for (int line = 0; line < numberOfInputLines; line++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string userName = input[1];
                string ip = input[0];
                int duration = int.Parse(input[2]);

                var user = users.FirstOrDefault(u => u.Name == userName);
                if (user == null)
                {
                    users.Add(new User(userName, ip, duration));
                }
                else
                {
                    if (!user.IPs.Contains(ip))
                    {
                        user.IPs = ip;
                    }

                    user.Duration += duration;
                }
            }

            var sortedUsers = users.OrderBy(user => user.Name);

            foreach (var user in sortedUsers)
            {
                Console.WriteLine("{0}: {1} [{2}]", user.Name, user.Duration, user.IPs);
            }
        }
    }

    class User
    {
        private List<string> ips;

        public User(string name, string ip, int duration)
        {
            this.ips = new List<string>();
            this.Name = name;
            this.IPs = ip;
            this.Duration = duration;
        }

        public string Name { get; set; }

        public string IPs 
        {
            get
            {
                return string.Join(", ", this.ips);
            }
            set
            {
                if (!this.ips.Contains(value))
                {
                    this.ips.Add(value);
                    this.ips.Sort();
                }
            }
        }

        public int Duration { get; set; }
    }
}
