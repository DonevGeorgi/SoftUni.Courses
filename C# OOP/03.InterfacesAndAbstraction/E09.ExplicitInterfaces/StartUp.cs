//Do not remove because of judge. Don
using PersonInfo.Models.Classes;
using PersonInfo.Models.Interface;
using System;
using System.Collections.Generic;

namespace PersonInfo;

public class StartUp
{
    static void Main()
    {
        List<Citizen> population = new();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

            Citizen person = new(inputArgs[0], inputArgs[1], int.Parse(inputArgs[2]));
            population.Add(person);
        }

        foreach (var currPerson in population)
        {
            Console.WriteLine(((IPerson)currPerson).GetName());
            Console.WriteLine(((IResident)currPerson).GetName());
        }
    }
}