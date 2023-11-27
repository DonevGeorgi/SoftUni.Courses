using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        //Constructor
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        //Properties
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        //Methods
        public override string ToString()
        {
            StringBuilder sb = new();

            string weight = this.Weight == 0 ? "n/a" : this.Weight.ToString();
            string color = this.Color ?? "n/a";

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($" {Engine.ToString()}");
            sb.AppendLine($"  Weight: {weight}");
            sb.AppendLine($"  Color: {color}");

            return sb.ToString().Trim();
        }
    }
}
