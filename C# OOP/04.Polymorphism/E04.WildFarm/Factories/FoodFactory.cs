using P04.WildFarm.Factories.Interface;
using P04.WildFarm.Models.FoodClasses;
using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood Create(string[] args)
        {
            IFood newFood = null;

            string type = args[0];
            int quantity = int.Parse(args[1]);

            if (type == "Vegetable")
            {
                IFood curFood = new Vegetable(quantity);

                newFood = curFood;
            }
            else if (type == "Fruit")
            {
                IFood curFood = new Fruit(quantity);

                newFood = curFood;
            }
            else if (type == "Meat")
            {
                IFood curFood = new Meat(quantity);

                newFood = curFood;
            }
            else if (type == "Seeds")
            {
                IFood curFood = new Seeds(quantity);

                newFood = curFood;
            }

            return newFood;
        }
    }
}
