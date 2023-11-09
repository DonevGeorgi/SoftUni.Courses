using System;

namespace Task02.ExamPreparation
{
    internal class ExamPreparation
    {
        static void Main()
        {
            int notSatisfiedGrade = int.Parse(Console.ReadLine());

            int badGradeCounter = 0;
            int problemsSolveCounter = 0;
            string lastProblemSolve = " ";

            int totalScore = 0;

            string nameOfTheTask;
            int grade;

            while (true)
            {
                nameOfTheTask = Console.ReadLine();

                if (nameOfTheTask == "Enough")
                {
                    break;
                }

                grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    badGradeCounter++;

                    if (badGradeCounter == notSatisfiedGrade)
                    {
                        break;
                    }
                }

                problemsSolveCounter++;
                lastProblemSolve = nameOfTheTask;
                totalScore += grade;
            }

            double averageScore = (double)totalScore / problemsSolveCounter;

            if (badGradeCounter < notSatisfiedGrade)
            {
                Console.WriteLine($"Average score: {averageScore:f2}");
                Console.WriteLine($"Number of problems: {problemsSolveCounter}");
                Console.WriteLine($"Last problem: {lastProblemSolve}");
            }
            else
            {
                Console.WriteLine($"You need a break, {badGradeCounter} poor grades.");
            }
        }
    }
}
