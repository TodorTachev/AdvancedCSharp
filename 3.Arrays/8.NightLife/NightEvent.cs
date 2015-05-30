using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.NightLife
{
    public class NightEvent
    {
        public string City { get; set; }
        public string Club { get; set; }
        public string Performer { get; set; }

        public NightEvent(string city, string club, string performer)
        {
            this.City = city;
            this.Club = club;
            this.Performer = performer;
        }
    }
}
