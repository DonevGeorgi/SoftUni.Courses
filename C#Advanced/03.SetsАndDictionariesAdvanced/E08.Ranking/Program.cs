using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Ranking
{
    internal class Program
    {
        static void Main()
        {
            Dictionary<string, string> contests = new();
            SortedDictionary<string, Dictionary<string, int>> contestands = new();

            InitializingContesands(contests);

            InitializingContest(contests, contestands);

            string bestContestand = contestands
                .OrderByDescending(c => c.Value.Values.Sum())
                .First().Key;

            int bestContestandsPoints = contestands[bestContestand].Values.Sum();

            Console.WriteLine($"Best candidate is {bestContestand} with total {bestContestandsPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var contestand in contestands)
            {
                Console.WriteLine(contestand.Key);

                Dictionary<string, int> orderedByPointsDesc = contestand.Value
                    .OrderByDescending(value => value.Value)
                    .ToDictionary(key => key.Key, key => key.Value);

                foreach (var contest in orderedByPointsDesc)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        static string InitializingContesands(Dictionary<string, string> contests)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of contests")
            {

                string[] inputArgs = input
                    .Split(":", StringSplitOptions.RemoveEmptyEntries);

                contests.Add(inputArgs[0], inputArgs[1]);
            }

            return input;
        }
        static void InitializingContest(Dictionary<string, string> contests, SortedDictionary<string, Dictionary<string, int>> candidates)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] inputArgs = input
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string contest = inputArgs[0];
                string password = inputArgs[1];
                string candidateName = inputArgs[2];
                int points = int.Parse(inputArgs[3]);

                if (contests.ContainsKey(contest)
                    && contests[contest] == password)
                {
                    if (!candidates.ContainsKey(candidateName))
                    {
                        candidates[candidateName] = new Dictionary<string, int>();
                    }

                    if (!candidates[candidateName].ContainsKey(contest))
                    {
                        candidates[candidateName].Add(contest, 0);
                    }

                    if (candidates[candidateName][contest] < points)
                    {
                        candidates[candidateName][contest] = points;
                    }
                }
            }
        }
    }
}
