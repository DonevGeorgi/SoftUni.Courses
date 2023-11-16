using System;
using System.Collections.Generic;
using System.Linq;

namespace E07.OrderByAge
{
    internal class OrderByAge
    {
        static void Main()
        {
            List<Person> peoples = new List<Person>();

            PeopleInitialization(peoples);

            PrintPeopleInAgeOrder(peoples);
        }

        static void PeopleInitialization(List<Person> peoples)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = inputArgs[0];
                string id = inputArgs[1];
                int age = int.Parse(inputArgs[2]);

                if (IsIdExisting(peoples, id))
                {
                    Person removedPerson = peoples.Find(x => x.Id == id);
                    int index = peoples.IndexOf(removedPerson);
                    peoples.Remove(removedPerson);
                    Person people = new Person(name, id, age);
                    peoples.Insert(index, people);
                }
                else
                {
                    Person people = new Person(name, id, age);
                    peoples.Add(people);
                }
            }
        }
        static bool IsIdExisting(List<Person> peoples, string id)
        {
            return peoples.Any(x => x.Id == id);
        }

        static void PrintPeopleInAgeOrder(List<Person> peoples)
        {
            List<Person> orderedPeoples = peoples
                            .OrderBy(x => x.Age)
                            .ToList();

            foreach (Person people in orderedPeoples)
            {
                Console.WriteLine($"{people.Name} with ID: {people.Id} is {people.Age} years old.");
            }
        }

        public class Person
        {
            public Person(string name, string id, int age)
            {
                this.Name = name;
                this.Id = id;
                this.Age = age;
            }
            public string Name { get; set; }
            public string Id { get; set; }
            public int Age { get; set; }

        }
    }
}
