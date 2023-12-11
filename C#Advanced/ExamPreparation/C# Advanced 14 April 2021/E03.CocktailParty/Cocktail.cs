using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcohol)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcohol;

            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (!Ingredients.Any(n => n.Name == ingredient.Name)
                && ingredient.Alcohol < MaxAlcoholLevel
                && Capacity > Ingredients.Count)
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            if (Ingredients.Any(n => n.Name == name))
            {
                Ingredients.Remove(Ingredients.Find(n => n.Name == name));

                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            if (Ingredients.Any(n => n.Name == name))
            {
                return Ingredients.FirstOrDefault(n => n.Name == name);
            }

            return null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return Ingredients.OrderByDescending(x => x.Alcohol).First();
        }

        public int CurrentAlcoholLevel => Ingredients.Sum(a => a.Alcohol);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (Ingredient ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
