using E04.PizzaCalories.Model;

namespace E04.PizzaCaliries.Models
{
    public class Pizza
    {
        private string name;
        private readonly List<Topping> topping;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            PizzaDough = dough;

            topping = new();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public void AddTopping(Topping currTopping)
        {
            if (Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            topping.Add(currTopping);
        }

        public Dough PizzaDough { get; private set; }

        public int Count => topping.Count;

        private double CalculateCaloriesOfThePizza()
        {
            double totalCalories = 0;

            foreach (var topping in topping)
            {
                totalCalories += topping.GetToppingCalories();
            }

            totalCalories += PizzaDough.GetDoughCalories();

            return totalCalories;
        }

        public override string ToString()
        {
            return $"{Name} - {CalculateCaloriesOfThePizza():f2} Calories.";
        }
    }
}
