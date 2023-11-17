using System;
using System.Collections.Generic;

namespace P05.Courses
{
    internal class Courses
    {
        static void Main()
        {
            Dictionary<string, List<string>> courses =
                new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArgs = input.Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string courseName = inputArgs[0];
                string studentName = inputArgs[1];

                if (!courses.ContainsKey(courseName))
                {
                    courses[courseName] = new List<string>();
                }

                courses[courseName].Add(studentName);
            }

            foreach (var course in courses)
            {
                string courseName = course.Key;
                List<string> students = course.Value;

                Console.WriteLine($"{courseName}: {students.Count}");

                foreach (var studentsName in students)
                {
                    Console.WriteLine($"-- {studentsName}");
                }
            }
        }
    }
}
