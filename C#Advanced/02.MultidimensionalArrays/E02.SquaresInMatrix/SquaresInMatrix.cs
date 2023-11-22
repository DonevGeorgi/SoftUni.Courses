using System;
using System.Linq;

namespace P02.SquaresInMatrix
{
    internal class SquareInMatrix
    {
        static void Main()
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int equalSquares = 0;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == (rows - 1) || col == (cols - 1))
                    {
                        continue;
                    }

                    char currChar = matrix[row, col];

                    if (currChar == matrix[row, col + 1]
                       && currChar == matrix[row + 1, col]
                       && currChar == matrix[row + 1, col + 1])
                    {
                        equalSquares++;
                    }
                }
            }

            Console.WriteLine(equalSquares);
        }
    }
}
