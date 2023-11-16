using System;
using System.Collections.Generic;
using System.Linq;

namespace E04.Students
{
    internal class Students
    {
        static void Main()
        {
            //Input
            int n = int.Parse(Console.ReadLine());

            List<Student> students = new List<Student>();

            string input = string.Empty;

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();

                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string firstName = inputArgs[0];
                string lastName = inputArgs[1];
                double grade = double.Parse(inputArgs[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            List<Student> sortedStudents = students
                .OrderByDescending(x => x.Grade)
                .ToList();

            foreach (Student student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        public class Student
        {
            public Student(string firstName, string lastName, double grade)
            {
                this.FirstName = firstName;
                this.LastName = lastName;
                this.Grade = grade;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public double Grade { get; set; }

            public override string ToString()
            {
                return $"{this.FirstName} {this.LastName}: {this.Grade:f2}";
            }
        }
    }
}
