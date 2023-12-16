using P04.WildFarm.Factories.Interface;
using P04.WildFarm.Models.AnimalClasses;
using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string[] args)
        {
            IAnimal newAnima = null;
            string type = args[0];

            if (type == "Owl")
            {
                string name = args[1];
                double weight = double.Parse(args[2]);
                double wingSize = double.Parse(args[3]);

                IAnimal currAnimal = new Owl(name,weight,wingSize);

                newAnima = currAnimal;
            }
            else if (type == "Hen")
            {
                string name = args[1];
                double weight = double.Parse(args[2]);
                double wingSize = double.Parse(args[3]);

                IAnimal currAnimal = new Hen(name, weight, wingSize);

                newAnima = currAnimal;
            }
            else if (type == "Mouse")
            {
                string name = args[1];
                double weight = double.Parse(args[2]);
                string livingRegion = args[3];

                IAnimal currAnimal = new Mouse(name, weight,livingRegion);

                newAnima = currAnimal;
            }
            else if (type == "Dog")
            {
                string name = args[1];
                double weight = double.Parse(args[2]);
                string livingRegion = args[3];

                IAnimal currAnimal = new Dog(name, weight, livingRegion);

                newAnima = currAnimal;
            }
            else if (type == "Cat")
            {
                string name = args[1];
                double weight = double.Parse(args[2]);
                string livingRegion = args[3];
                string breed = args[4];

                IAnimal currAnimal = new Cat(name, weight, livingRegion,breed);

                newAnima = currAnimal;
            }
            else if (type == "Tiger")
            {
                string name = args[1];
                double weight = double.Parse(args[2]);
                string livingRegion = args[3];
                string breed = args[4];

                IAnimal currAnimal = new Tiger(name, weight, livingRegion, breed);

                newAnima = currAnimal;
            }

            return newAnima;
        }
    }
}
