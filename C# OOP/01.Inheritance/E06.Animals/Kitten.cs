using System;

namespace Animals
{
    public class Kitten : Cat
    {
        private const string kittensGender = "Female";
        public Kitten(string name, int age)
            : base(name, age, kittensGender)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }

        public override string ToString()
        {
            return $"{Name} {Age} {Gender}{Environment.NewLine}{ProduceSound()}";
        }
    }
}
