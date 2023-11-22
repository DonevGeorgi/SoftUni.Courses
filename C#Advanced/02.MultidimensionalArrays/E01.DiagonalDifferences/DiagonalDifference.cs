using System;
using System.Data;
using System.Linq;

namespace P01.DiagonalDifference
{
    internal class DiagonalDifference
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int rows = n;
            int cols = n;

            int primaryDiagonal = 0;
            int reverseDiagonal = 0;

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }


            for (int i = 0; i < rows; i++)
            {
                primaryDiagonal += matrix[i, i];
                reverseDiagonal += matrix[rows - 1 - i, i];
            }

            Console.WriteLine(Math.Abs(reverseDiagonal - primaryDiagonal));
        }
    }
}
