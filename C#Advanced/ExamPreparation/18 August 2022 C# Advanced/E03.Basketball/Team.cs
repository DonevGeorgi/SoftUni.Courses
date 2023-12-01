using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        //Constructor
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;

            this.players = new List<Player>();
        }

        //Properties
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> players { get; set; }

        //Methods
        public int Count => players.Count;

        public string AddPlayer(Player player)
        {
            if (player.Name == null || player.Position == null || player.Name == "" || player.Position == "")
            {
                return "Invalid player's information.";
            }

            if (this.OpenPositions < 0)
            {
                return "There are no more open positions.";
            }

            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            players.Add(player);
            this.OpenPositions--;

            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        //passed
        public bool RemovePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                this.OpenPositions++;
                return players.Remove(players.Find(x => x.Name == name));
            }

            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int count = 0;

            foreach (var player in players)
            {
                if (player.Position == position)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                return 0;
            }

            players.RemoveAll(x => x.Position == position);

            this.OpenPositions += count;

            return count;
        }

        public Player RetirePlayer(string name)
        {
            if (players.Any(x => x.Name == name))
            {
                foreach (var player in players)
                {
                    if (player.Name == name)
                    {
                        player.Retired = true;
                        return player;
                    }
                }
            }

            return null;
        }

        public List<Player> AwardPlayers(int games)
        {
            return players.Where(x => x.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (var player in players.Where(x => x.Retired != true))
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
