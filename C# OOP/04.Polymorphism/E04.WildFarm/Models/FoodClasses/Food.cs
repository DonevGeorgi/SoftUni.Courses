using P04.WildFarm.Models.Interfaces;

namespace P04.WildFarm.Models.FoodClasses
{
    public abstract class Food : IFood
    {
        public Food(int quantity) 
        {
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
    }
}
