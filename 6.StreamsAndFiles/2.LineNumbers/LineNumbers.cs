//Write a program that reads a text file and inserts line numbers in front of each of its lines. 
//The result should be written to another text file. Use StreamReader in combination with StreamWriter.

using System;
using System.IO;

class LineNumbers
{
    static void Main()
    {
        StreamReader reader = new StreamReader("file.txt");
        StreamWriter writer = new StreamWriter("result.txt");
        using (reader)
        {
            using (writer)
            {
                string line;
                for (int i = 0; (line = reader.ReadLine()) != null; i++)
                {
                    writer.WriteLine("{0,2}   {1}", i, line);
                }
            }
        }
    }
}