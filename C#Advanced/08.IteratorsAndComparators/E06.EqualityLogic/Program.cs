using System;
using System.Collections.Generic;

namespace P06.EqualityLogic
{
    internal class Program
    {
        static void Main()
        {
            HashSet<Person> peoples = new();
            SortedSet<Person> sortedPeoples = new();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] peopleData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new(peopleData[0], int.Parse(peopleData[1]));

                peoples.Add(person);
                sortedPeoples.Add(person);
            }

            Console.WriteLine(peoples.Count);
            Console.WriteLine(sortedPeoples.Count);
        }
    }
}
