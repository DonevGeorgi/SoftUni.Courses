//Do not remove because of judge. Don't put in folders because of the namespace.
using System;
using System.Collections.Generic;

namespace PersonInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        List<IIdentifiable> allPassedThePost = new();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs.Length == 3)
            {
                Citizen currPassing = new(inputArgs[0], int.Parse(inputArgs[1]), inputArgs[2]);
                allPassedThePost.Add(currPassing);
            }
            else if (inputArgs.Length == 2)
            {
                Robots currPassing = new(inputArgs[0], inputArgs[1]);
                allPassedThePost.Add(currPassing);
            }
        }

        string fakeId = Console.ReadLine();

        foreach (IIdentifiable currCheck in allPassedThePost)
        {
            if (currCheck.Id.EndsWith(fakeId))
            {
                Console.WriteLine(currCheck.Id);
            }
        }
    }
}