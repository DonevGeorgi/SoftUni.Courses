using System;

namespace P01.ValidUsername
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in input)
            {
                bool isUnvalid = true;

                if (word.Length > 3 && word.Length <= 16)
                {
                    foreach (char letter in word)
                    {
                        if (!(char.IsLetterOrDigit(letter) || letter == '_' || letter == '-'))
                        {
                            isUnvalid = false;
                            break;
                        }
                    }

                    if (isUnvalid)
                    {
                        Console.WriteLine(word);
                    }
                }
            }

        }
    }
}
