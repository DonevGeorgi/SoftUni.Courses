using System;
using System.Linq;

namespace P03.MaximalSum
{
    internal class MaximalSum
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int bestSum = int.MinValue;
            int sum = 0;
            int bestRow = 0;
            int bestCol = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    sum = 0;

                    if (row > rows - 3 || col > cols - 3)
                    {
                        continue;
                    }

                    for (int i = row; i <= row + 2; i++)
                    {
                        for (int k = col; k <= col + 2; k++)
                        {
                            sum += matrix[i, k];
                        }
                    }

                    if (bestSum < sum)
                    {
                        bestSum = sum;
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {bestSum}");

            for (int row = bestRow; row <= bestRow + 2; row++)
            {
                for (int col = bestCol; col <= bestCol + 2; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
