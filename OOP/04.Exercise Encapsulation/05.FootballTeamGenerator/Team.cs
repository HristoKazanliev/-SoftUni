using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private readonly List<Player> players;

        public Team(string name)
        {
            this.Name = name;
            this.players = new List<Player>();
        }

        public string Name { get; set; }

        public void AddPlayers(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayers(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                throw new Exception($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(player);

            //Player player = players.FirstOrDefault(p => p.Name == playerName);
            //return players.Remove(player);
        }

        public double Rating
            => players.Count == 0
                ? 0
                : Math.Round(this.players.Average(p => p.Stats));
        
    }
}
