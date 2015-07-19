using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ITVillage
{
    class Program
    {
        private const int BoardDimentions = 4;
        private const int AmountOfCoinsInTheBeginning = 50;
        private const int GoldPerInn = 20;

        private static string[,] board;
        private static string[] boardRows;
        private static int[] position;
        private static int[] turns;
        private static int coins;
        private static int inns;
        private static int allInnsOnBoard;
        private static bool hasWonByNakov;

        static void Main()
        {
            Input();

            InitializeGameParameters();

            for (int turn = 0; turn < turns.Length && coins >= 0 && !hasWonByNakov && inns < allInnsOnBoard; turn++)
            {
                coins += GoldPerInn * inns;
                Move(turn);
                turn += OutcomeAfterTurn();
            }

            Output();
        }

        private static void InitializeGameParameters()
        {
            board = new string[BoardDimentions, BoardDimentions];
            allInnsOnBoard = 0;
            int index = 0;
            FillBoard(index);
            coins = AmountOfCoinsInTheBeginning;
            inns = 0;
            hasWonByNakov = false;
        }

        private static void Output()
        {
            if (coins < 0)
            {
                Console.WriteLine("<p>You lost! You ran out of money!<p>");
            }
            else if (inns == allInnsOnBoard)
            {
                Console.WriteLine("<p>You won! You own the village now! You have {0} coins!<p>", coins);
            }
            else if (hasWonByNakov)
            {
                Console.WriteLine("<p>You won! Nakov's force was with you!<p>");
            }
            else
            {
                Console.WriteLine("<p>You lost! No more moves! You have {0} coins!<p>", coins);
            }
        }

        private static int OutcomeAfterTurn()
        {
            switch (board[position[0], position[1]])
            {
                case "P":
                    coins -= 5;
                    return 0;
                case "I":
                    if (coins >= 100)
                    {
                        coins -= 100;
                        inns++;
                    }
                    else
                    {
                        coins -= 10;
                    }

                    return 0;
                case "S":
                    coins -= GoldPerInn * inns;
                    return 2;
                case "V":
                    coins *= 10;
                    return 0;
                case "F":
                    coins += 20;
                    return 0;
                case "N":
                    hasWonByNakov = true;
                    return 0;
                default:
                    return 0;
            }
        }

        private static void Move(int turn)
        {
            while (turns[turn] > 0)
            {
                bool hasMoved = false;

                if (position[0] == 0 && position[1] != 3 && !hasMoved)
                {
                    position[1]++;
                    hasMoved = true;
                }

                if (position[0] != 3 && position[1] == 3 && !hasMoved)
                {
                    position[0]++;
                    hasMoved = true;
                }

                if (position[0] == 3 && position[1] != 0 && !hasMoved)
                {
                    position[1]--;
                    hasMoved = true;
                }

                if (position[0] != 0 && position[1] == 0 && !hasMoved)
                {
                    position[0]--;
                    hasMoved = true;
                }

                turns[turn]--;
            }
        }

        private static void Input()
        {
            boardRows = Console.ReadLine().Split('|');

            position = Console.ReadLine()
                .Split(' ')
                .Select(p => int.Parse(p) - 1)
                .ToArray();

            turns = Console.ReadLine()
                .Split(' ')
                .Select(turn => int.Parse(turn))
                .ToArray();
        }

        private static void FillBoard(int index)
        {
            string[] row = boardRows[index].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (row[col] == "I")
                {
                    allInnsOnBoard++;
                }

                board[index, col] = row[col];
            }

            if (index != board.GetUpperBound(0))
            {
                FillBoard(index + 1);
            }
        }
    }
}
