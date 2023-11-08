using System;

namespace Task07.TrekkingMania
{
    internal class TrekkingMania
    {
        static void Main()
        {
            int groupCount = int.Parse(Console.ReadLine());

            int musalaCount = 0;
            int monbalCount = 0;
            int kilimandjaroCount = 0;
            int k2Count = 0;
            int everestCount = 0;

            int allPeople = 0;

            for (int i = 1; i <= groupCount; i++)
            {
                int peopleInGroup = int.Parse(Console.ReadLine());

                allPeople += peopleInGroup;

                if (peopleInGroup <= 5)
                {
                    musalaCount += peopleInGroup;
                }
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                {
                    monbalCount += peopleInGroup;
                }
                else if (peopleInGroup >= 12 && peopleInGroup <= 25)
                {
                    kilimandjaroCount += peopleInGroup;
                }
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                {
                    k2Count += peopleInGroup;
                }
                else if (peopleInGroup >= 41)
                {
                    everestCount += peopleInGroup;
                }
            }

            double finalmusalaCount = (double)musalaCount / allPeople * 100.0;
            double finalmonbalCount = (double)monbalCount / allPeople * 100.0;
            double finalkilimandjaroCount = (double)kilimandjaroCount / allPeople * 100.0;
            double finalk2Count = (double)k2Count / allPeople * 100.0;
            double finaleverestCount = (double)everestCount / allPeople * 100.0;

            Console.WriteLine($"{finalmusalaCount:f2}%");
            Console.WriteLine($"{finalmonbalCount:f2}%");
            Console.WriteLine($"{finalkilimandjaroCount:f2}%");
            Console.WriteLine($"{finalk2Count:f2}%");
            Console.WriteLine($"{finaleverestCount:f2}%");

        }
    }
}
