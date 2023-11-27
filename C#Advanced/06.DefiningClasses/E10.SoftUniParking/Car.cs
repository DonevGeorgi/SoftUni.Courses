using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        //Constructor
        public Car(string make, string model, int horsePower, string registration)
        {
            this.Make = make;
            this.Model = model;
            this.HorsePower = horsePower;
            this.RegistrationNumber = registration;
        }

        //Properties
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        //Methods
        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Make: {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"HorsePower: {this.HorsePower}");
            sb.AppendLine($"RegistrationNumber: {this.RegistrationNumber}");

            return sb.ToString().Trim();
        }
    }
}
