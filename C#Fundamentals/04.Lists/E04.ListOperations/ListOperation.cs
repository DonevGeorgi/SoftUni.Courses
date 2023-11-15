using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.ListOperation
{
    internal class ListOperation
    {
        static void Main(string[] args)
        {
            List<int> listWhitNums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "Add")
                {
                    int number = int.Parse(inputArgs[1]);

                    listWhitNums.Add(number);
                }
                else if (inputArgs[0] == "Insert")
                {
                    int number = int.Parse(inputArgs[1]);
                    int index = int.Parse(inputArgs[2]);

                    if (index < 0 || index >= listWhitNums.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    listWhitNums.Insert(index, number);
                }
                else if (inputArgs[0] == "Remove")
                {
                    int index = int.Parse(inputArgs[1]);

                    if (index < 0 || index >= listWhitNums.Count)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    listWhitNums.RemoveAt(index);
                }
                else if (inputArgs[1] == "left")
                {
                    int rotations = int.Parse(inputArgs[2]);

                    for (int i = 0; i < rotations; i++)
                    {
                        int firstNum = listWhitNums[0];

                        listWhitNums.RemoveAt(0);
                        listWhitNums.Add(firstNum);
                    }
                }
                else if (inputArgs[1] == "right")
                {
                    int rotation = int.Parse(inputArgs[2]);

                    for (int i = 0; i < rotation; i++)
                    {
                        int lastNum = listWhitNums[listWhitNums.Count - 1];

                        listWhitNums.RemoveAt(listWhitNums.Count - 1);
                        listWhitNums.Insert(0, lastNum);
                    }
                }
            }

            Console.WriteLine(String.Join(" ", listWhitNums));
        }
    }
}
