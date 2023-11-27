using System.Text;

namespace DefiningClasses
{
    public class Engine
    {
        //Constructor
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }


        //Properties
        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string displacement = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();
            string efficiency = this.Efficiency ?? "n/a";

            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power.ToString()}");
            sb.AppendLine($"    Displacement: {displacement}");
            sb.AppendLine($"    Efficiency: {efficiency}");

            return sb.ToString().Trim();
        }
    }
}
