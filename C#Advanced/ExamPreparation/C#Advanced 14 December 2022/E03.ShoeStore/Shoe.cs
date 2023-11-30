using System;

namespace ShoeStore
{
    public class Shoe
    {
        //Fields
        private string brand;
        private string type;
        private double size;
        private string material;

        //Constructor
        public Shoe(string brand, string type, double size, string material)
        {
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        //Properties
        public string Brand { get; set; }
        public string Type { get; set; }
        public double Size { get; set; }
        public string Material { get; set; }

        //Methods
        public override string ToString()
        {
            return $"Size {this.Size}, {this.Material} {this.Brand} {this.Type} shoe.";
        }
    }
}
