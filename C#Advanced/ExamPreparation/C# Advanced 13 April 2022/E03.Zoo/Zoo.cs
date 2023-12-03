using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;

            Animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Animal> Animals { get; private set; }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrEmpty(animal.Species))
            {
                return "Invalid animal species.";
            }

            if (!(animal.Diet == "herbivore" || animal.Diet == "carnivore"))
            {
                return "Invalid animal diet.";
            }

            if (Animals.Count == Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            int count = 0;

            foreach (Animal animal in Animals)
            {
                if (animal.Species == species)
                {
                    count++;
                }
            }

            Animals.RemoveAll(x => x.Species == species);
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.FindAll(d => d.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(w => w.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (Animal animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
