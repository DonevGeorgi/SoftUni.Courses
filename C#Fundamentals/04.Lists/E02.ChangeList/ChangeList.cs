using System;
using System.Collections.Generic;
using System.Linq;

namespace E02.ChangeList
{
    internal class ChangeList
    {
        static void Main()
        {
            List<int> listWhitNumbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "Delete")
                {
                    int number = int.Parse(inputArgs[1]);

                    listWhitNumbers.RemoveAll(x => x == number);
                }
                else if (inputArgs[0] == "Insert")
                {
                    int element = int.Parse(inputArgs[1]);
                    int position = int.Parse(inputArgs[2]);

                    listWhitNumbers.Insert(position, element);
                }
            }

            Console.WriteLine(String.Join(" ", listWhitNumbers));
        }
    }
}
