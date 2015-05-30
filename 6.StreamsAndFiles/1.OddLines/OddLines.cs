//Write a program that reads a text file and prints on the console its odd lines. 
//Line numbers starts from 0. Use StreamReader.

using System;
using System.IO;

class OddLines
{
    static void Main()
    {
        StreamReader sr = new StreamReader("file.txt");
        using (sr)
        {
            string line; 
            while ((line = sr.ReadLine()) != null)
            {
                line = sr.ReadLine();
                Console.WriteLine(line);
            }
        }
    }
}