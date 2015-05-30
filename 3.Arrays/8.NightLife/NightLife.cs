using _8.NightLife;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NightLife
{
    static void Main()
    {
        List<string> keys = new List<string>();
        List<NightEvent> nightEvent = new List<NightEvent>();
        while (true)
        {
            string input = Console.ReadLine();
            if (input == "END")
            {
                break;
            }
            string[] inputArr = input.Split(';');
            nightEvent.Add(new NightEvent(inputArr[0], inputArr[1], inputArr[2]));
        }
        var eventQuery = nightEvent.GroupBy(x => x.City);
        foreach (var city in eventQuery)
        {
            Console.WriteLine(city.Key);
            var clubs = city.GroupBy(x => x.Club).OrderBy(x => x.Key); 
            foreach (var club in clubs)
            {
                Console.Write("->" + club.Key + ":");
                var performers = club.GroupBy(x => x.Performer).OrderBy(x => x.Key);
                foreach (var performer in performers)
                {
                    keys.Add(performer.Key);
                    Console.Write(String.Join(", ", keys));
                }
                keys.Clear();
                Console.WriteLine();
            }
        }
    }
}