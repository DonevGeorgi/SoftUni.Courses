using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P09.SoftUniExamResults
{
    internal class SoftUniExamResults
    {
        static void Main()
        {
            Dictionary<string, int> exam = new Dictionary<string, int>();

            Dictionary<string, int> submissions
                = new Dictionary<string, int>();

            InitializingExam(exam, submissions);

            PrintingResults(exam, submissions);
        }

        static void InitializingExam(Dictionary<string, int> exam, Dictionary<string, int> submissions)
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] inputArgs = input
                    .Split("-", StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 3)
                {
                    string name = inputArgs[0];
                    string language = inputArgs[1];
                    int points = int.Parse(inputArgs[2]);

                    if (!exam.ContainsKey(name))
                    {
                        exam[name] = points;
                    }

                    if (exam[name] < points)
                    {
                        exam[name] = points;
                    }

                    FollowingSubmissions(submissions, language);
                }
                else if (inputArgs.Length == 2)
                {
                    string name = inputArgs[0];

                    exam.Remove(name);
                }
            }
        }
        static void PrintingResults(Dictionary<string, int> exam, Dictionary<string, int> submissions)
        {
            Console.WriteLine("Results:");

            foreach (var participant in exam.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var language in submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }

        private static void FollowingSubmissions(Dictionary<string, int> submissions, string language)
        {
            if (!submissions.ContainsKey(language))
            {
                submissions[language] = 0;
            }

            submissions[language]++;
        }
    }
}
