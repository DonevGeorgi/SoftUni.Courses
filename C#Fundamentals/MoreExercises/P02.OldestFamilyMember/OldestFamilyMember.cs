using System;
using System.Collections.Generic;
using System.Linq;

namespace P02.OldestFamilyMember
{
    internal class OldestFamilyMember
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Family currentFamily = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person member = new Person(input[0], int.Parse(input[1]));
                currentFamily.AddMember(member);
            }

            Person oldest = currentFamily.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }

        class Person
        {
            public Person(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }

            public string Name { get; set; }
            public int Age { get; set; }
        }
        class Family
        {
            public Family()
            {
                this.People = new List<Person>();
            }

            public List<Person> People { get; set; }

            public void AddMember(Person member)
            {
                People.Add(member);
            }
            public Person GetOldestMember()
            {
                Person oldestPerson = People.OrderByDescending(x => x.Age).FirstOrDefault();
                return oldestPerson;
            }
        }
    }
}
