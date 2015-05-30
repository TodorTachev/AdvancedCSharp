using System;
using System.Text.RegularExpressions;
using System.Text;

class Chains
{
    static void Main()
    {
        string input = Console.ReadLine();

        string tagPattern = @"(?<=\<p\>)(.|\n)*?(?=\<\/p)";
        Regex tagRgx = new Regex(tagPattern);
        MatchCollection tagContent = tagRgx.Matches(input);

        string tag;
        StringBuilder manual = new StringBuilder();
                
        string spacePattern1 = @"[^a-z0-9]+";
        Regex spaceRgx1 = new Regex(spacePattern1);

        foreach (var match in tagContent)
        {
            tag = spaceRgx1.Replace(match.ToString(), " ");
            manual.Append(tag);
        }

        for (int index = 0; index < manual.Length; index++)
        {
            if (manual[index] != ' ' &&
                manual[index] != '1' &&
                manual[index] != '2' &&
                manual[index] != '3' &&
                manual[index] != '4' &&
                manual[index] != '5' &&
                manual[index] != '6' &&
                manual[index] != '7' &&
                manual[index] != '8' &&
                manual[index] != '9' &&
                manual[index] != '0')
            {
                int place = manual[index] % 32;
                if (place <= 13)
                {
                    manual[index] = (char)(manual[index] + 13);
                }
                else
                {
                    manual[index] = (char)(manual[index] - 13);
                }
            }
        }
        Console.WriteLine(manual);
    }
}