using System;
using System.Diagnostics.CodeAnalysis;

namespace P05.ComparingObjects
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            Name = name;
            Age = age;
            Town = town;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Town { get; set; }

        public int CompareTo(Person person)
        {
            int result = Name.CompareTo(person.Name);

            if (result != 0)
            {
                return result;
            }

            result = Age.CompareTo(person.Age);

            if (result != 0)
            {
                return result;
            }

            return Town.CompareTo(person.Town);
        }
    }
}
