using System;
using System.Collections;

namespace P06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person people)
        {
            int result = Name.CompareTo(people.Name);

            if (result != 0)
            {
                return Name.CompareTo(people.Name);
            }

            result = Age.CompareTo(people.Age);

            return result;
        }

        public override bool Equals(object obj)
        {
            Person currPerson = obj as Person;

            if (currPerson == null)
            {
                return false;
            }

            return Name == currPerson.Name && Age == currPerson.Age;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() + Age.GetHashCode();
        }
    }
}
