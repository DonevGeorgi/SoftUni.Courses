using System;

namespace E07.NxN.Matrix
{
    internal class NxnMatrix
    {
        static void Main(string[] args)
        {
            //input
            int n = int.Parse(Console.ReadLine());

            //Method for matrix
            MakingNxNMatrix(n);
        }

        static void MakingNxNMatrix(int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int k = 0; k < n; k++)
                {
                    Console.Write($"{n} ");
                }

                Console.WriteLine();
            }
        }
    }
}
