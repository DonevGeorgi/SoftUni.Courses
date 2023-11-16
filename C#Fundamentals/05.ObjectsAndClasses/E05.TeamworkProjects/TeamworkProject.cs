using System;
using System.Collections.Generic;
using System.Linq;

namespace E05.TeamworkProject
{
    internal class TeamworkProject
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();

            TeamInitialization(teams);
            JoiningPlayersInTeams(teams);

            PrintingTeams(teams);
            DisbandedTeams(teams);
        }

        static void JoiningPlayersInTeams(List<Team> teams)
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] commandArgs = command.Split("->");

                string nameOfPlayer = commandArgs[0];
                string teamName = commandArgs[1];

                if (!TriedToJoinNonExistingTeam(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (DoesTeamContainThePlayer(teams, nameOfPlayer))
                {
                    Console.WriteLine($"Member {nameOfPlayer} cannot join team {teamName}!");
                }
                else
                {
                    Team joinTeam = teams.First(x => x.TeamName == teamName);
                    joinTeam.AddMember(nameOfPlayer);
                }
            }
        }
        static bool TriedToJoinNonExistingTeam(List<Team> teams, string teamName)
        {
            return teams.Any(x => x.TeamName == teamName);
        }
        static bool DoesTeamContainThePlayer(List<Team> teams, string nameOfPlayer)
        {
            return teams.Any(x => x.Members.Contains(nameOfPlayer)) ||
                teams.Any(x => x.Creator == nameOfPlayer);
        }
        static string TeamInitialization(List<Team> teams)
        {
            int n = int.Parse(Console.ReadLine());

            string input = string.Empty;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();

                string[] inputArgs = input.Split("-");

                string creatorName = inputArgs[0];
                string teamName = inputArgs[1];

                if (DoTeamExistAlready(teams, teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (DoCreatorAlreadyHaveTeam(teams, creatorName))
                {
                    Console.WriteLine($"{creatorName} cannot create another team!");
                }
                else
                {
                    Console.WriteLine($"Team {teamName} has been created by {creatorName}!");

                    Team team = new Team(creatorName, teamName);
                    teams.Add(team);
                }
            }

            return input;
        }
        static bool DoTeamExistAlready(List<Team> teams, string teamName)
        {
            return teams.Any(x => x.TeamName == teamName);
        }
        static bool DoCreatorAlreadyHaveTeam(List<Team> teams, string creatorName)
        {
            return teams.Any(x => x.Creator == creatorName);
        }
        static void PrintingTeams(List<Team> teams)
        {
            List<Team> orderedTeams = teams
                            .Where(x => x.Members.Count > 0)
                            .OrderByDescending(x => x.Members.Count)
                            .ThenBy(x => x.TeamName)
                            .ToList();

            foreach (Team team in orderedTeams)
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (string memberName in team.Members.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {memberName}");
                }
            }
        }
        static void DisbandedTeams(List<Team> teams)
        {
            List<Team> DisbandedTeams = teams
                            .Where(x => x.Members.Count == 0)
                            .OrderBy(x => x.TeamName)
                            .ToList();

            Console.WriteLine("Teams to disband:");
            foreach (Team team in DisbandedTeams)
            {
                Console.WriteLine(team.TeamName);
            }
        }

        public class Team
        {
            private readonly List<string> member;

            public Team(string creator, string teamName)
            {
                this.Creator = creator;
                this.TeamName = teamName;

                this.member = new List<string>();
            }

            public string Creator { get; set; }
            public string TeamName { get; set; }


            public List<string> Members
                => this.member;

            public void AddMember(string memberName)
            {
                this.member.Add(memberName);
            }
        }
    }
}
