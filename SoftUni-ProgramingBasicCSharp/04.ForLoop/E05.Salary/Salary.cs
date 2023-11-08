using System;

namespace Task05.Salary
{
    internal class Salary
    {
        static void Main()
        {
            int openTabs = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());

            for (int i = 1; i <= openTabs; i++)
            {
                string saits = Console.ReadLine();

                if (saits == "Facebook")
                {
                    salary -= 150;
                }
                else if (saits == "Instagram")
                {
                    salary -= 100;
                }
                else if (saits == "Reddit")
                {
                    salary -= 50;
                }

                if (salary <= 0)
                {
                    break;
                }
            }

            if (salary <= 0)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary);
            }
        }
    }
}
