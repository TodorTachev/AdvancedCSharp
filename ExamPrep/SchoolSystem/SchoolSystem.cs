using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem
{
    class SchoolSystem
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, List<int>>> data = new Dictionary<string, Dictionary<string, List<int>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                string name = input[0] + " " + input[1];
                string subject = input[2];
                int score = int.Parse(input[3]);
                if (!data.ContainsKey(name))
                {
                    Dictionary<string, List<int>> subjectAndScores = new Dictionary<string, List<int>>();
                    List<int> scores = new List<int>();
                    scores.Add(score);
                    subjectAndScores[subject] = scores;
                    data[name] = subjectAndScores;
                }
                else
                {
                    Dictionary<string, List<int>> subjectAndScores = data[name];
                    if (!subjectAndScores.ContainsKey(subject))
                    {
                        List<int> scores = new List<int>();
                        scores.Add(score);
                        subjectAndScores[subject] = scores;
                    }
                    else
                    {
                        subjectAndScores[subject].Add(score);
                    }
                }
            }
            var sortedNames = data.OrderBy(name => name.Key);
            List<string> results = new List<string>();
            foreach (var name in sortedNames)
            {
                string fullName = name.Key;
                var sortedSubjectsAndScores = data[fullName].OrderBy(subj => subj.Key);
                foreach (var subjectAndScores in sortedSubjectsAndScores)
                {
                    string subject = subjectAndScores.Key;
                    List<int> scores = data[fullName][subject];
                    double averageScore = scores.Average();
                    results.Add(String.Format("{0} - {1:F2}", subject, averageScore));
                }
                Console.WriteLine(fullName + ": [" + String.Join(", ", results) + "]");
                results.Clear();
            }
        }
    }
}
