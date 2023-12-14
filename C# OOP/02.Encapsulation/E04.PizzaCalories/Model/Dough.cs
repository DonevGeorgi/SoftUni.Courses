using System.Diagnostics.Contracts;

namespace E04.PizzaCaliries.Models
{
    public class Dough
    {
        private const int CaloriesPerGram = 2;
        private readonly Dictionary<string, double> flourTypesCalories;
        private readonly Dictionary<string, double> bakingTechniquesCalories;

        private string flourType;
        private string bakingTechnique;
        private double grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            flourTypesCalories =
            new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };

            bakingTechniquesCalories =
                new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };

            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string FlourType
        {
            get => flourType;
            private set
            {
                if (!flourTypesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value.ToLower();
            }
        }

        public string BakingTechnique
        {
            get => bakingTechnique;
            private set
            {
                if (!bakingTechniquesCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value.ToLower();
            }
        }

        public double Grams
        {
            get => grams;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }

                grams = value;
            }
        }

        public double GetDoughCalories() => CalculatingCaloriesOfTheDough();

        private double CalculatingCaloriesOfTheDough()
        {
            double totalCalories = 0;

            totalCalories = (CaloriesPerGram * Grams) * flourTypesCalories[FlourType.ToLower()] * bakingTechniquesCalories[BakingTechnique.ToLower()];

            return totalCalories;
        }
    }
}
