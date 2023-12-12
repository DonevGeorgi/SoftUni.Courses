using System.Dynamic;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
            : base(name, age)
        {
        }
        public int Age
        {
            get
            {
                return base.Age;
            }
            set
            {
                if (value < 15)
                {
                    base.Age = value;
                }
            }

        }

        public override string ToString()
        {
            return $"Name: {Name}, Age: {Age}";
        }
    }
}

