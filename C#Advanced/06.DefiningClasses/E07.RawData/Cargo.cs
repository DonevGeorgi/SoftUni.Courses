namespace DefiningClasses
{
    public class Cargo
    {
        //Constructor
        public Cargo(string type, int weight)
        {
            this.Type = type;
            this.Weight = weight;
        }

        //Properties
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}
