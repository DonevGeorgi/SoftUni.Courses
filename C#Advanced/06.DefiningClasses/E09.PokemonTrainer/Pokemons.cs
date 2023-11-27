namespace DefiningClasses
{
    public class Pokemons
    {
        //Constructos
        public Pokemons(string name, string element, int health)
        {
            this.Name = name;
            this.Element = element;
            this.Health = health;
        }

        //Properties
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}
