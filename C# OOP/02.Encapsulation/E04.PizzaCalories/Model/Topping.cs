namespace E04.PizzaCaliries.Models
{
    public class Topping
    {
        private const int BaseCaloriesPerGram = 2;
        private readonly Dictionary<string, double> types;

        private string type;
        private double grams;
        private double calories;

        public Topping(string type, double grams)
        {
            types = new Dictionary<string, double> { { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, { "sauce", 0.9 } };

            Type = type;
            Grams = grams;
        }

        public string Type
        {
            get => type;
            private set
            {
                if (!types.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }

        public double Grams
        {
            get => grams;
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public double GetToppingCalories() => CalculatingCaloriesOfTheTopping();

        private double CalculatingCaloriesOfTheTopping()
        {
            double toppingTypeModifier = 0;

            calories = (BaseCaloriesPerGram * Grams) * types[Type.ToLower()];

            return calories;
        }
    }
}
