﻿using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Linq;

class DirectoryTraversal
{
    static void Main()
    {
        Console.WriteLine("Enter directory:");
        string input = Console.ReadLine() + "\\";
        string output = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt");
        Regex rgx = new Regex(@"([\w\d\W]*)\\(?<=\\)([\w\d\W]*)(?=\.)(\.\w+)");
        Dictionary<string, int> fileTypeCount = new Dictionary<string, int>();
        Dictionary<string, Dictionary<string, double>> fileTypeEntries = new Dictionary<string, Dictionary<string, double>>();
        string[] files = Directory.GetFiles(input);
        
        foreach (string file in files)
        {
            FileInfo f = new FileInfo(file);
            double fileSize = Math.Round(f.Length / 1024.0, 3);
            Match match = rgx.Match(file);
            string fileType = match.Groups[3].Value;
            string fileName = String.Format("{0}{1}", match.Groups[2].Value, fileType); 

            if (!fileTypeCount.ContainsKey(fileType))
            {
                fileTypeCount.Add(fileType, 1);
                fileTypeEntries.Add(fileType, new Dictionary<string, double>());
                fileTypeEntries[fileType].Add(fileName, fileSize);
            }
            else
            {
                fileTypeCount[fileType]++;
                fileTypeEntries[fileType].Add(fileName, fileSize);
            }
        }

        using (StreamWriter writer = new StreamWriter(output, false, Encoding.UTF8))
        {
            foreach (KeyValuePair<string, int> pairCount in SortDictByValueDescending(fileTypeCount))
            {
                writer.WriteLine(pairCount.Key);
                foreach (KeyValuePair<string, double> pairSize in SortDictByValueAscending(fileTypeEntries[pairCount.Key]))
                {
                    writer.WriteLine("--{0} - {1:##.###}kb", pairSize.Key, pairSize.Value);
                }
            }
        }

        System.Diagnostics.Process.Start(output);
    }

    static IOrderedEnumerable<KeyValuePair<string, int>> SortDictByValueDescending(Dictionary<string, int> dictToSort)
    {
        var sorted = from pair in dictToSort orderby pair.Value descending, pair.Key ascending select pair;
        return sorted;
    }

    static IOrderedEnumerable<KeyValuePair<string, double>> SortDictByValueAscending(Dictionary<string, double> dictToSort)
    {
        var sorted = from pair in dictToSort orderby pair.Value ascending, pair.Key ascending select pair;
        return sorted;
    }
}