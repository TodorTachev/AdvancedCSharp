namespace X_Removal
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<string> input = new List<string>();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "END")
                {
                    break;
                }

                input.Add(inputLine);
            }

            string[][] text = new string[input.Count][];
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();

            for (int index = 0; index < input.Count; index++)
            {
                text[index] = input[index].ToCharArray().Select(ch => ch.ToString()).ToArray();
            }

            for (int row = 1; row < text.Length; row++)
            {
                for (int col = 1; col < text[row].Length; col++)
                {
                    try
                    {
                        if (text[row][col].ToLower() == text[row - 1][col - 1].ToLower() &&
                            text[row][col].ToLower() == text[row + 1][col - 1].ToLower() &&
                            text[row][col].ToLower() == text[row - 1][col + 1].ToLower() &&
                            text[row][col].ToLower() == text[row + 1][col + 1].ToLower())
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
                text[rows[index]][cols[index]] = string.Empty;
                text[rows[index] - 1][cols[index] - 1] = string.Empty;
                text[rows[index] + 1][cols[index] - 1] = string.Empty;
                text[rows[index] - 1][cols[index] + 1] = string.Empty;
                text[rows[index] + 1][cols[index] + 1] = string.Empty;
            }

            for (int row = 0; row < text.Length; row++)
            {
                for (int col = 0; col < text[row].Length; col++)
                {
                    Console.Write(text[row][col]);
                }
                Console.WriteLine();
            }
        }
    }
}
