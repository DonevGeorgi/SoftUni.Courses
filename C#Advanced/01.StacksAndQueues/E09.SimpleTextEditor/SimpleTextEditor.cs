using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.SimpleTextEditor
{
    internal class SimpleTextEditor
    {
        static void Main()
        {
            string text = string.Empty;

            Stack<string> history = new Stack<string>();

            int n = int.Parse(Console.ReadLine());

            string pointedIndexes = string.Empty;

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "1")
                {
                    history.Push(text);
                    text += command[1];
                }
                else if (command[0] == "2")
                {
                    int index = int.Parse(command[1]);
                    history.Push(text);
                    text = text.Remove(text.Length - index, index);
                }
                else if (command[0] == "3")
                {
                    int index = int.Parse(command[1]) - 1;
                    pointedIndexes += text[index];
                }
                else if (command[0] == "4")
                {
                    text = history.Pop();
                }
            }


            foreach (var letter in pointedIndexes)
            {
                Console.WriteLine(letter);
            }
        }
    }
}
