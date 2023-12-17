using ValidationAttributes.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int MinAgeRequirement = 12;
        private const int MaxAgeRequirement = 90;

        public Person(string fullName,int age) 
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(MinAgeRequirement, MaxAgeRequirement)]
        public int Age { get; private set; }
    }
}
