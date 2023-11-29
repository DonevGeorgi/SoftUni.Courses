using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.ListyIterator
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();

            ListyIterator<string> list = new(items);

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                if (command == "Move")
                {
                    Console.WriteLine(list.Move());
                }
                else if (command == "Print")
                {
                    try
                    {
                        list.Print();
                    }
                    catch (InvalidOperationException exception)
                    {
                        Console.WriteLine(exception.Message);
                    }
                }
                else if (command == "HasNext")
                {
                    Console.WriteLine(list.HasNext());
                }
            }
        }
    }
}
