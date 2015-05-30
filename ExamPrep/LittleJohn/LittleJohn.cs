using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LittleJohn
{
    class LittleJohn
    {
        static void Main()
        {
            int smallArrowCount = 0;
            int medArrowCount = 0;
            int bigArrowCount = 0;
            string smallArrowPattern = @"(?<!\>)(>----->)(?!\>)";
            string medArrowPattern = @"(?<!\>)(>>----->)(?!\>)";
            string bigArrowPattern = @"(?<!\>)(>>>----->>)(?!\>)";
            Regex smallArrowRgx = new Regex(smallArrowPattern);
            Regex medArrowRgx = new Regex(medArrowPattern);
            Regex bigArrowRgx = new Regex(bigArrowPattern);
            for (int i = 0; i < 4; i++)
            {
                string input = Console.ReadLine();
                if (smallArrowRgx.IsMatch(input))
                {
                    MatchCollection smallArrow = smallArrowRgx.Matches(input);
                    smallArrowCount += smallArrow.Count;
                }
                if (medArrowRgx.IsMatch(input))
                {
                    MatchCollection medArrow = medArrowRgx.Matches(input);
                    medArrowCount += medArrow.Count;
                }
                if (bigArrowRgx.IsMatch(input))
                {
                    MatchCollection bigArrow = bigArrowRgx.Matches(input);
                    bigArrowCount += bigArrow.Count;
                }
            }
            string allArrows = smallArrowCount.ToString() + medArrowCount.ToString() + bigArrowCount.ToString();
            string binArrows = Convert.ToString(Convert.ToInt32(allArrows, 10), 2);
            char[] binArrowsArr = binArrows.ToCharArray();
            Array.Reverse(binArrowsArr);
            string binArrowsReversed = new String(binArrowsArr);
            string binResult = binArrows + binArrowsReversed;
            string result = Convert.ToString(Convert.ToInt32(binResult, 2), 10);
            Console.WriteLine(result);
        }
    }
}
