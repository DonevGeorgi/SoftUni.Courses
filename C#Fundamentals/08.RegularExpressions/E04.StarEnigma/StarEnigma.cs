using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace P04.StarEnigma
{
    internal class StarEnigma
    {

        static void Main()
        {
            string patern = @"\@(?<planet>[A-Z][a-z]+)[^\@\-\!\:\>]*?\:(?<population>\d+)[^\@\-\!\:\>]*?\!(?<attackType>[A-Z])\![^\@\-\!\:\>]*?\-\>(?<soldiers>\d+)[^\@\-\!\:\>]*?";
            Regex regex = new Regex(patern);

            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string decryptedMassage = DecryptionOfMassige(input);

                Match match = regex.Match(decryptedMassage);

                if (match.Groups["attackType"].Value == "A")
                {
                    attackedPlanets.Add(match.Groups["planet"].Value);
                }
                else if (match.Groups["attackType"].Value == "D")
                {
                    destroyedPlanets.Add(match.Groups["planet"].Value);
                }
            }

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");

            foreach (var attacked in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {attacked}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");

            foreach (var destroyed in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {destroyed}");
            }
        }

        static string DecryptionOfMassige(string message)
        {
            StringBuilder newMessage =
            new StringBuilder();

            int count = 0;

            foreach (char letter in message.ToLower())
            {
                if (letter == 's' || letter == 't' || letter == 'a' || letter == 'r')
                {
                    count++;
                }
            }

            foreach (char letter in message)
            {
                newMessage.Append((char)(letter - count));
            }

            return newMessage.ToString();
        }
    }
}
