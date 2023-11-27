using System.Collections.Generic;

namespace DefiningClasses
{
    public class Trainer
    {
        //Constructor
        public Trainer(string name)
        {
            Pokemons = new();

            this.Name = name;
        }

        //Properties
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemons> Pokemons { get; set; }

        //Method
        public void AddPokemon(string name, string type, int health)
        {
            Pokemons.Add(new(name, type, health));
        }

        public void RemovePokemon(Pokemons pokemon)
        {
            Pokemons.Remove(pokemon);
        }

        public void TakingDamage(int damage)
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= damage;
            }

            Pokemons.RemoveAll(p => p.Health <= 0);
        }
    }
}
