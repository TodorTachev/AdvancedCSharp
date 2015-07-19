using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserLogs
{
    class Program
    {
        static void Main()
        {
            var logs = new Dictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "end")
                {
                    break;
                }

                string[] input = inputLine.Split(' ');
                string ip = input[0].Remove(0, 3);
                string user = input[2].Remove(0, 5);

                if (!logs.ContainsKey(user))
                {
                    logs[user] = new Dictionary<string, int>();
                }
                
                if (!logs[user].ContainsKey(ip))
                {
                    logs[user].Add(ip, 1);
                }
                else
                {
                    logs[user][ip] += 1;
                }
            }

            var sortedLogsByUser = logs.OrderBy(log => log.Key);

            foreach (var log in sortedLogsByUser)
            {
                var ips = new List<string>();

                foreach (var ip in logs[log.Key])
                {
		            ips.Add(string.Format("{0} => {1}", ip.Key, ip.Value));
                }

                Console.WriteLine("{0}:{1}{2}.", log.Key, Environment.NewLine, string.Join(", ", ips));
            }
        }
    }
}
