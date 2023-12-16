using P04.WildFarm.Factories.Interface;
using P04.WildFarm.Core.Interfaces;
using P04.WildFarm.IO.Reader.Interface;
using P04.WildFarm.IO.Writer.Interface;
using P04.WildFarm.Factories;
using P04.WildFarm.Models.Interfaces;
using P04.WildFarm.Models.AnimalClasses;

namespace P04.WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IWriter writer;
        public readonly IReader reader;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IWriter consoleWtiter, IReader consoleReader, IFoodFactory foodFactory,IAnimalFactory animalFactory)
        {
            this.writer = consoleWtiter;
            this.reader = consoleReader;
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;

            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = reader.ReaderLine()) != "End")
            {
                IAnimal animal = null;

                try
                {
                    animal = CreateAnimal(input);

                    IFood food = CreateFood(input);

                    writer.WriteLine(animal.ProduceSound());

                    animal.Eat(food);

                }
                catch (ArgumentException ex)
                {
                    writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }

                animals.Add(animal);
            }

            foreach (IAnimal animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
        

        private IAnimal CreateAnimal(string input)
        {
            string[] animaArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return animalFactory.Create(animaArgs);
        }
        private IFood CreateFood(string input)
        {
            string[] foodArgs = reader.ReaderLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            return foodFactory.Create(foodArgs);
        }
    }
}
