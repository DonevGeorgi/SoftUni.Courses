using System;
using System.Collections.Generic;
using System.Linq;

namespace E08.AnonymousThreat
{
    internal class AnonymousThreat
    {
        static void Main()
        {
            List<string> text = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "3:1")
            {
                string[] inputArgs = input.Split(" ");

                if (inputArgs[0] == "merge")
                {
                    int startIndex = int.Parse(inputArgs[1]);
                    int endIndex = int.Parse(inputArgs[2]);

                    string currWord = string.Empty;
                    string newText = string.Empty;

                    if (startIndex < 0)
                    {
                        startIndex = 0;
                    }

                    if (startIndex >= text.Count)
                    {
                        startIndex = text.Count - 1;
                    }

                    if (endIndex <= 0)
                    {
                        endIndex = 0;
                    }

                    if (endIndex >= text.Count)
                    {
                        endIndex = text.Count - 1;
                    }

                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        currWord = text[startIndex];
                        newText += currWord;
                        text.RemoveAt(startIndex);
                    }

                    text.Insert(startIndex, newText);

                }
                else if (inputArgs[0] == "divide")
                {
                    int indexForDivision = int.Parse(inputArgs[1]);
                    int parts = int.Parse(inputArgs[2]);

                    string word = text[indexForDivision];

                    int partsLenth = word.Length / parts;
                    int lastPart = partsLenth + word.Length % parts;

                    List<string> partsList = new List<string>();

                    for (int i = 0; i < parts; i++)
                    {
                        int addedParts = partsLenth;
                        if (i == parts - 1)
                        {
                            addedParts = lastPart;
                        }

                        char[] newPartitionArr = word
                        .Skip(i * partsLenth)
                        .Take(addedParts)
                        .ToArray();

                        string newPartition = String.Join("", newPartitionArr);
                        partsList.Add(newPartition);
                    }

                    text.RemoveAt(indexForDivision);
                    text.InsertRange(indexForDivision, partsList);
                }
            }

            Console.WriteLine(string.Join(" ", text));
        }
    }
}
