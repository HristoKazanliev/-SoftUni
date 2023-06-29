using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> teams = new Dictionary<string, Team>();

            string input = Console.ReadLine();
            while (input!="END")
            {
                string[] inputArray = input.Split(';');
                string action = inputArray[0];
                string teamName = inputArray[1];

                try
                {
                    if (action == "Team")
                    {
                        Team team = new Team(teamName);
                        teams.Add(teamName, team);
                    }
                    else if (action == "Add")
                    {
                        if (teams.ContainsKey(teamName))
                        {
                            string playerName = inputArray[2];
                            int endurance = int.Parse(inputArray[3]);
                            int sprint = int.Parse(inputArray[4]);
                            int dribble = int.Parse(inputArray[5]);
                            int passing = int.Parse(inputArray[6]);
                            int shooting = int.Parse(inputArray[7]);

                            Player playerToAdd = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                            teams[teamName].AddPlayers(playerToAdd);
                        }
                        else Console.WriteLine($"Team {teamName} does not exist.");

                        //if (!teams.ContainsKey(teamName))
                        //{
                        //    Console.WriteLine($"Team {teamName} does not exist.");
                        //    input = Console.ReadLine();
                        //    continue;
                        //}

                        //string playerName = inputArray[2];
                        //int endurance = int.Parse(inputArray[3]);
                        //int sprint = int.Parse(inputArray[4]);
                        //int dribble = int.Parse(inputArray[5]);
                        //int passing = int.Parse(inputArray[6]);
                        //int shooting = int.Parse(inputArray[7]);

                        //Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        //teams[teamName].AddPlayers(player);
                    }
                    else if (action == "Remove")
                    {
                        string playerToRemove = inputArray[2];
                        teams[teamName].RemovePlayers(playerToRemove);

                        //if (!teams.ContainsKey(teamName))
                        //{
                        //    Console.WriteLine($"Team {teamName} does not exist.");
                        //    input = Console.ReadLine();
                        //    continue;
                        //}

                        //string playerName = inputArray[2];
                        //bool remove = teams[teamName].RemovePlayers(playerName);
                        //if (!remove)
                        //{
                        //    Console.WriteLine($"Player {playerName} is not in {teamName} team.");
                        //    input = Console.ReadLine();
                        //    continue;
                        //}
                    }
                    else if (action == "Rating")
                    {
                        if (teams.ContainsKey(teamName))
                            Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                        else
                            Console.WriteLine($"Team {teamName} does not exist.");

                        //if (!teams.ContainsKey(teamName))
                        //{
                        //    Console.WriteLine($"Team {teamName} does not exist.");
                        //    input = Console.ReadLine();
                        //    continue;
                        //}

                        //Console.WriteLine($"{teamName} - {teams[teamName].Rating}");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }

                input = Console.ReadLine();
            }
        }
    }
}
