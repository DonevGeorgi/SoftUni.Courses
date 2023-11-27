namespace DefiningClasses
{
    public class Tires
    {
        //Constructor
        public Tires(int age, double pressure)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        //Properties
        public int Age { get; set; }
        public double Pressure { get; set; }
    }
}
