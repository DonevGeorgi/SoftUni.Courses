using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            this.roster = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public void AddPlayer(Player player)
        {
            if (Capacity > roster.Count)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            if (roster.Any(n => n.Name == name))
            {
                roster.Remove(roster.Find(n => n.Name == name));

                return true;
            }

            return false;
        }

        public void PromotePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                if (player.Rank != "Member")
                {
                    roster[roster.IndexOf(player)].Rank = "Member";
                }
            }
        }

        public void DemotePlayer(string name)
        {
            var player = roster.FirstOrDefault(x => x.Name == name);

            if (player != null)
            {
                if (player.Rank != "Member")
                {
                    roster[roster.IndexOf(player)].Rank = "Member";
                }
            }
        }

        public Player[] KickPlayersByClass(string clas)
        {

            Player[] kicked = roster.Where(n => n.Class == clas).ToArray();

            roster.RemoveAll(n => n.Class == clas);

            return kicked;
        }

        public int Count => roster.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (Player player in roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
