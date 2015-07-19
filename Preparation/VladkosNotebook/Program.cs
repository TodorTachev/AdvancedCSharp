namespace VladkosNotebook
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            List<Player> players = new List<Player>();
            while (true)
            {
                string inputLine = Console.ReadLine();
                if (inputLine == "END")
                {
                    break;
                }

                string[] pageData = inputLine.Split('|');
                Player player = players.FirstOrDefault(pl => pl.Color == pageData[0]);

                if (player == null)
                {
                    Player newPlayer = new Player(pageData[0]);
                    switch (pageData[1])
                    {
                        case "win":
                            newPlayer.WinCounter++;
                            newPlayer.Opponents.Add(pageData[2]);
                            break;
                        case "loss":
                            newPlayer.LossCounter++;
                            newPlayer.Opponents.Add(pageData[2]);
                            break;
                        case "name":
                            newPlayer.Name = pageData[2];
                            break;
                        case "age":
                            newPlayer.Age = int.Parse(pageData[2]);
                            break;
                    }
                    players.Add(newPlayer);
                }
                else
                {
                    switch (pageData[1])
                    {
                        case "win":
                            player.WinCounter++;
                            player.Opponents.Add(pageData[2]);
                            break;
                        case "loss":
                            player.LossCounter++;
                            player.Opponents.Add(pageData[2]);
                            break;
                        case "name":
                            player.Name = pageData[2];
                            break;
                        case "age":
                            player.Age = int.Parse(pageData[2]);
                            break;
                    }
                }
            }

            if (players.Any(pl => pl.Name != null && pl.Age != 0))
            {
                var sortedPlayers = players.Where(pl => pl.Name != null && pl.Age != 0)
                                           .OrderBy(pl => pl.Color);
                foreach (var player in sortedPlayers)
                {
                    Console.WriteLine(player);
                }
            }
            else
            {
                Console.WriteLine("No data recovered.");
            }
        }
    }

    class Player
    {
        public Player(string color)
        {
            this.WinCounter = 0;
            this.LossCounter = 0;
            this.Opponents = new List<string>();
            this.Color = color;
        }

        public string Color { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int WinCounter { get; set; }

        public int LossCounter { get; set; }

        public List<string> Opponents { get; set; }

        private double GetRank()
        {
            return (this.WinCounter + 1) / (double)(this.LossCounter + 1);
        }

        public override string ToString()
        {
            this.Opponents.Sort(StringComparer.Ordinal);
            StringBuilder output = new StringBuilder();
            output.AppendFormat("Color: {0}{1}", this.Color, Environment.NewLine);
            output.AppendFormat("-age: {0}{1}", this.Age, Environment.NewLine);
            output.AppendFormat("-name: {0}{1}", this.Name, Environment.NewLine);
            output.AppendFormat("-opponents: {0}{1}", 
                                                    this.Opponents.Count == 0 ? "(empty)" : string.Join(", ", this.Opponents), 
                                                    Environment.NewLine);
            output.AppendFormat("-rank: {0:F2}", this.GetRank());
            return output.ToString();
        }
    }
}
