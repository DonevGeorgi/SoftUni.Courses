using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => char.Parse(x))
                .ToArray());

            Stack<char> consonants = new Stack<char>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => char.Parse(x))
                .ToArray());

            HashSet<char> usedLetters = new HashSet<char>();

            while (consonants.Any())
            {
                char currVowel = vowels.Peek();
                char currConsonant = consonants.Pop();

                usedLetters.Add(currVowel);
                usedLetters.Add(currConsonant);

                vowels.Enqueue(vowels.Dequeue());
            }

            List<string> words = new List<string>();

            words.Add("pear");
            words.Add("flour");
            words.Add("pork");
            words.Add("olive");

            List<string> finalWords = new List<string>();

            foreach (var word in words)
            {
                bool notHole = true;

                foreach (char letter in word)
                {
                    if (!usedLetters.Contains(letter))
                    {
                        notHole = false;
                    }
                }

                if (notHole)
                {
                    finalWords.Add(word);
                }
            }

            Console.WriteLine($"Words found: {finalWords.Count}");

            foreach (var word in finalWords)
            {
                Console.WriteLine(word);
            }

        }
    }
}

