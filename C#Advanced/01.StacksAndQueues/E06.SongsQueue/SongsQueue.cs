using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.SongsQueue
{
    internal class SongsQueue
    {
        static void Main()
        {
            Queue<string> songs = new Queue<string>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while (songs.Any())
            {
                string[] command = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (command[0] == "Play")
                {
                    songs.Dequeue();
                }
                else if (command[0] == "Add" && songs.Any())
                {
                    string currSong = string.Join(" ", command[1..]);

                    if (!(songs.Contains(currSong)))
                    {
                        songs.Enqueue(currSong);
                    }
                    else
                    {
                        Console.WriteLine($"{currSong} is already contained!");
                    }
                }
                else if (command[0] == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
