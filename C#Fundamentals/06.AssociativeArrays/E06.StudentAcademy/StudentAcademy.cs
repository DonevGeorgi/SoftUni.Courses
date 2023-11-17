using System;
using System.Collections.Generic;

namespace P06.StudentAcademy
{
    internal class StudentAcademy
    {
        static void Main()
        {
            Dictionary<string, List<decimal>> students =
                new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string studentsName = Console.ReadLine();
                decimal studentGrade = decimal.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentsName))
                {
                    students[studentsName] = new List<decimal>();
                }

                students[studentsName].Add(studentGrade);
            }


            foreach (var student in students)
            {
                decimal averageGrade = 0;
                decimal totalGrade = 0;
                List<decimal> grades = student.Value;

                foreach (decimal grade in grades)
                {
                    totalGrade += grade;
                }

                averageGrade = totalGrade / student.Value.Count;

                if (averageGrade >= 4.50m)
                {
                    Console.WriteLine($"{student.Key} -> {averageGrade:f2}");
                }
            }
        }
    }
}
