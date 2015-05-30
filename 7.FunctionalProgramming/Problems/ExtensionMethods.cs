using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems
{
    public static class ExtensionMethods
    {
        public static bool TwoBadMarks(this IList<int> marks)
        {
            int count = marks.Count(mark => mark == 2);
            if (count == 2)
            {
                return true;
            }
            return false;
        }

        public static bool IsThereStudentsOf2014(this int facultyNumber)
        {
            if (facultyNumber % 100 == 14)
            {
                return true;
            }
            return false;
        }
    }
}
