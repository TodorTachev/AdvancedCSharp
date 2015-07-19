using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parachute
{
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

            char[,] environment = new char[input.Count, input[0].Length];

            for (int row = 0; row < environment.GetLength(0); row++)
            {
                for (int col = 0; col < environment.GetLength(1); col++)
                {
                    environment[row, col] = input[row][col];
                }
            }

            
            int wind = 0;

            for (int row = 0; row < environment.GetUpperBound(0); row++)
            {
                for (int col = 0; col < environment.GetLength(1); col++)
                {
                    if (environment[row, col] == 'o')
                    {
                        for (int index = 0; index < environment.GetLength(1); index++)
                        {
                            if (environment[row + 1, index] == '>')
                            {
                                wind++;
                            }

                            if (environment[row + 1, index] == '<')
                            {
                                wind--;
                            }
                        }
                        
                        switch (environment[row + 1, col + wind])
                        {
                            case '/':
                            case '\\':
                            case '|':
                                Console.WriteLine("Got smacked on the rock like a dog!");
                                Console.WriteLine("{0} {1}", row + 1, col + wind);
                                return;
                            case '~':
                                Console.WriteLine("Drowned in the water like a cat!");
                                Console.WriteLine("{0} {1}", row + 1, col + wind);
                                return;
                            case '_':
                                Console.WriteLine("Landed on the ground like a boss!");
                                Console.WriteLine("{0} {1}", row + 1, col + wind);
                                return;
                            default:
                                environment[row + 1, col + wind] = 'o';
                                break;
                        }
                    }
                }

                wind = 0;
            }
        }
    }
}
