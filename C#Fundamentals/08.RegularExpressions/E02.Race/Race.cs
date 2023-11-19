using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace P02.Race
{
    internal class Race
    {
        static void Main()
        {
            Dictionary<string, int> participants =
                new Dictionary<string, int>();

            string[] racers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            ÍnitializingParticipants(participants, racers);

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end of race")
            {
                string nameOfTheParticipant = string.Empty;
                int distance = 0;

                foreach (char letter in input)
                {
                    if (char.IsDigit(letter))
                    {
                        distance += int.Parse(letter.ToString());
                    }
                    else if (char.IsLetter(letter))
                    {
                        nameOfTheParticipant += letter;
                    }
                }

                if (participants.ContainsKey(nameOfTheParticipant))
                {
                    participants[nameOfTheParticipant] += distance;
                }
            }

            int count = 0;

            foreach (var participant in participants.OrderByDescending(x => x.Value))
            {
                if (count == 0)
                {
                    Console.WriteLine($"1st place: {participant.Key}");
                }
                else if (count == 1)
                {
                    Console.WriteLine($"2nd place: {participant.Key}");
                }
                else if (count == 2)
                {
                    Console.WriteLine($"3rd place: {participant.Key}");
                }
                else
                {
                    break;
                }

                count++;
            }
        }

        static void ÍnitializingParticipants(Dictionary<string, int> participants, string[] racers)
        {
            for (int i = 0; i < racers.Length; i++)
            {
                if (!participants.ContainsKey(racers[i]))
                {
                    participants[racers[i]] = 0;
                }
            }
        }

    }
}
