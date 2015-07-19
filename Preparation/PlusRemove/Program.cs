namespace PlusRemove
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        static void Main()
        {
            StringBuilder input = new StringBuilder();
            while (true)
            {
                string inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                input.AppendLine(inputLine);
            }

            string[] inputArr = input.ToString().Split('\n');
            string[][] textToSearch = new string[inputArr.Length][];

            for (int index = 0; index < inputArr.Length; index++)
            {
                textToSearch[index] = inputArr[index].ToCharArray().Select(ch => ch.ToString()).ToArray();
            }

            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            for (int row = 1; row < textToSearch.Length - 1; row++)
            {
                for (int col = 1; col < textToSearch[row].Length - 1; col++)
                {
                    try
                    {
                        if (textToSearch[row][col].ToLower() == textToSearch[row - 1][col].ToLower() &&
                        textToSearch[row][col].ToLower() == textToSearch[row + 1][col].ToLower() &&
                        textToSearch[row][col].ToLower() == textToSearch[row][col - 1].ToLower() &&
                        textToSearch[row][col].ToLower() == textToSearch[row][col + 1].ToLower())
                        {
                            rows.Add(row);
                            cols.Add(col);
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        break;
                    }
                }
            }

            for (int index = 0; index < rows.Count; index++)
            {
                textToSearch[rows[index]][cols[index]] = string.Empty;
                textToSearch[rows[index] - 1][cols[index]] = string.Empty;
                textToSearch[rows[index] + 1][cols[index]] = string.Empty;
                textToSearch[rows[index]][cols[index] - 1] = string.Empty;
                textToSearch[rows[index]][cols[index] + 1] = string.Empty;
            }

            for (int row = 0; row < textToSearch.LongLength; row++)
            {
                for (int col = 0; col < textToSearch[row].Length; col++)
                {
                    Console.Write(textToSearch[row][col]);
                }
            }
        }
    }
}
