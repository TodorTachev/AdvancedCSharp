//Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file text.txt. 
//Matching should be case-insensitive.
//Write the results in file results.txt. Sort the words by frequency in descending order. 
//Use StreamReader in combination with StreamWriter

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class WordCount
{
    static void Main()
    {
        StreamReader wordsReader = new StreamReader("words.txt");
        StreamReader textReader = new StreamReader("text.txt");
        StreamWriter resultWriter = new StreamWriter("results.txt");
        Dictionary<string, int> results = new Dictionary<string, int>();
        using (wordsReader)
        {
            using (textReader)
            {
                using (resultWriter)
                {
                    string text = textReader.ReadToEnd();
                    string[] textArr = text.Split(new char[] { ' ', ',', '?', '.', '!', ':', '-', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    string keyWord;
                    while ((keyWord = wordsReader.ReadLine()) != null)
                    {
                        int count = 0;
                        for (int i = 0; i < textArr.Length; i++)
                        {
                            if (String.Compare(textArr[i], keyWord, true) == 0)
                            {
                                count++;
                                results[keyWord] = count;
                            }
                        }
                    }
                    foreach (var entry in results.OrderBy(i => -i.Value))
                    {
                        resultWriter.WriteLine(entry);
                    }
                }
            }
        }
    }
}