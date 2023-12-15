//Do not remove because of judge. Don'
using PersonInfo.Models.Classes;
using System;
using System.Collections.Generic;

namespace PersonInfo;

public class StartUp
{
    static void Main()
    {
        Dictionary<string, List<int>> addedElements = new();

        addedElements["AddCollection"] = new();
        addedElements["AddRemoveCollection"] = new();
        addedElements["MyList"] = new();

        Dictionary<string, List<string>> removedElements = new();

        removedElements["RemovedFromAddRemoveCollection"] = new();
        removedElements["RemovedFromMyList"] = new();

        AddCollection addCollection = new();
        AddRemoveCollection addRemoveCollection = new();
        MyList myList = new();

        string[] elements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
        int removeOperation = int.Parse(Console.ReadLine());

        for (int i = 0; i < elements.Length; i++)
        {
            addedElements["AddCollection"].Add(addCollection.Add(elements[i]));
            addedElements["AddRemoveCollection"].Add(addRemoveCollection.Add(elements[i]));
            addedElements["MyList"].Add(myList.Add(elements[i]));
        }

        for (int i = 0; i < removeOperation; i++)
        {
            removedElements["RemovedFromAddRemoveCollection"].Add(addRemoveCollection.Remove());
            removedElements["RemovedFromMyList"].Add(myList.Remove());
        }



        Console.WriteLine(string.Join(" ", addedElements["AddCollection"]));
        Console.WriteLine(string.Join(" ", addedElements["AddRemoveCollection"]));
        Console.WriteLine(string.Join(" ", addedElements["MyList"]));

        Console.WriteLine(string.Join(" ", removedElements["RemovedFromAddRemoveCollection"]));
        Console.WriteLine(string.Join(" ", removedElements["RemovedFromMyList"]));
    }
}