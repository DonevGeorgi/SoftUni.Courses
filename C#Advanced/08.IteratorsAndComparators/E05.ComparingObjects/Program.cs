using System;
using System.Collections.Generic;

namespace P05.ComparingObjects
{
    internal class Program
    {
        static void Main()
        {
            List<Person> persons = new();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new(personData[0], int.Parse(personData[1]), personData[2]);

                persons.Add(person);
            }

            int index = int.Parse(Console.ReadLine());

            Person comperablePerson = persons[index - 1];

            int countMatches = 0;
            int numberOfDifferentPerson = 0;

            foreach (var person in persons)
            {
                if (person.CompareTo(comperablePerson) == 0)
                {
                    countMatches++;
                }
                else
                {
                    numberOfDifferentPerson++;
                }
            }

            if (countMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countMatches} {numberOfDifferentPerson} {persons.Count}");
            }
        }
    }
}
