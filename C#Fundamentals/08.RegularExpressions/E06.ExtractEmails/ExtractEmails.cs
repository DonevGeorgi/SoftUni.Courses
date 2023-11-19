using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace P06.ExtractEmails
{
    internal class ExtractEmails
    {
        static void Main()
        {
            string patenrs = @"(?<=\s)([a-zA-Z0-9]+)([\-\._]?)([a-zA-Z0-9]+)\@([a-zA-Z]+([\.\-_][a-zA-Z]+)+)(\b|(?=\s))";
            Regex regex = new Regex(patenrs);

            string input = Console.ReadLine();

            MatchCollection matchs = regex.Matches(input);

            List<string> emails = new List<string>();

            foreach (Match match in matchs)
            {
                emails.Add(match.Value);
            }

            foreach (var email in emails)
            {
                Console.WriteLine(email);
            }
        }
    }
}
