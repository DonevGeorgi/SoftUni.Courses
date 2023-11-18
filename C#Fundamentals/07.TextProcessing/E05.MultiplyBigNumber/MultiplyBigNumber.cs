using System;
using System.Text;

namespace P05.MultiplyBigNumber
{
    internal class MultiplyBigNumber
    {
        static void Main()
        {
            string input = Console.ReadLine();

            int multiplyer = int.Parse(Console.ReadLine());

            StringBuilder resultNum = new StringBuilder();

            int reminder = 0;

            if (multiplyer == 0 || input == "0")
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int currentNum = int.Parse(input[i].ToString());
                int currentResult = currentNum * multiplyer + reminder;
                int result = currentResult % 10;
                reminder = currentResult / 10;

                resultNum.Insert(0, result);
            }

            if (reminder > 0)
            {
                resultNum.Insert(0, reminder);
            }

            Console.WriteLine(resultNum.ToString());
        }
    }
}
