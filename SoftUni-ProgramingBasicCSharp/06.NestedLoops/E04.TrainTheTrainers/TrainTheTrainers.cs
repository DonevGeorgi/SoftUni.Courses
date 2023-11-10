using System;

namespace Task04.TrainTheTrainers
{
    internal class TrainTheTrainers
    {
        static void Main()
        {
            int juryMemberNum = int.Parse(Console.ReadLine());

            string input = "";
            double totalGradeForCourse = 0;
            int lectureCounter = 0;

            while ((input = Console.ReadLine()) != "Finish")
            {
                string lectureTitle = input;
                lectureCounter++;

                double totalGradeForLecture = 0;

                for (int i = 1; i <= juryMemberNum; i++)
                {
                    double gradeForLecture = double.Parse(Console.ReadLine());

                    totalGradeForLecture += gradeForLecture;
                }

                double averageForLecture = totalGradeForLecture / juryMemberNum;
                Console.WriteLine($"{lectureTitle} - {averageForLecture:f2}.");

                totalGradeForCourse += averageForLecture;
            }

            double averageForCourse = totalGradeForCourse / lectureCounter;
            Console.WriteLine($"Student's final assessment is {averageForCourse:f2}.");
        }
    }
}
