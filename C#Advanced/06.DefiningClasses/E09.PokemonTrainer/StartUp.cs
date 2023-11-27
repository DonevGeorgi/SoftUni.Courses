using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] trainerData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (!trainers.Any(x => x.Name == trainerData[0]))
                {
                    Trainer trainer = new(trainerData[0]);
                    trainer.AddPokemon(trainerData[1], trainerData[2], int.Parse(trainerData[3]));
                    trainers.Add(trainer);
                }
                else
                {
                    trainers.Find(x => x.Name == trainerData[0]).AddPokemon(trainerData[1], trainerData[2], int.Parse(trainerData[3]));
                }

            }

            string type = string.Empty;

            while ((type = Console.ReadLine()) != "End")
            {
                foreach (var currTrainer in trainers)
                {
                    if (currTrainer.Pokemons.Any(x => x.Element == type))
                    {
                        currTrainer.NumberOfBadges++;
                    }
                    else
                    {
                        currTrainer.TakingDamage(10);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x => x.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }
    }
}