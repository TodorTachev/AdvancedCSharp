using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChatLogger
{
    class Program
    {
        static void Main()
        {
            var chatLog = new Dictionary<DateTime, string>();
            DateTime currentTime = DateTime.Parse(Console.ReadLine());
            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                string[] input = inputLine.Split('/');
                DateTime date = DateTime.Parse(input[1].Trim());
                string message = input[0].Trim();
                chatLog[date] = message;
            }

            var sortedChatLog = chatLog.OrderBy(chat => chat.Key);

            foreach (var log in sortedChatLog)
            {
                Console.WriteLine("<div>{0}</div>", log.Value);
            }

            string timestamp = string.Empty;
            TimeSpan lastActive = currentTime - sortedChatLog.Last().Key;

            if (lastActive.TotalMinutes < 1)
            {
                timestamp = "a few moments ago";
            }
            else if (lastActive.TotalMinutes >= 1 && lastActive.TotalHours < 1)
            {
                timestamp = string.Format("{0} minute(s) ago", lastActive.TotalMinutes);
            }
            else if (lastActive.TotalHours >= 1 && lastActive.TotalHours < 24)
            {
                timestamp = string.Format("{0} hour(s) ago", lastActive.TotalHours);
            }
            else if (lastActive.TotalHours >= 24 && lastActive.TotalDays < 2)
            {
                timestamp = "yesterday";
            }
            else if (lastActive.TotalDays >= 2)
            {
                timestamp = lastActive.ToString("dd-mm-yyyy");
            }

            Console.WriteLine("<p>Last active: <time>{0}</time></p>", timestamp);
        }
    }
}
