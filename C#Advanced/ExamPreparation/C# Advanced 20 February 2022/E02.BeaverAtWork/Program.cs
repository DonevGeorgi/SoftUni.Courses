using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int rows = size;
            int cols = size;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            List<char> woodCollected = new List<char>();

            int count = 0;

            string direction = string.Empty;

            while ((direction = Console.ReadLine()) != "end")
            {
                int[] locationOfBeaver = LocatingBeaver(matrix, size);

                int beaverRow = locationOfBeaver[0];
                int beaverCol = locationOfBeaver[1];

                MakeMove(size, matrix, woodCollected, direction, ref beaverRow, ref beaverCol);

                count = IsWoodCollected(size, matrix);

                if (count == 0)
                {
                    break;
                }
            }

            count = IsWoodCollected(size, matrix);

            if (count == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {woodCollected.Count} wood branches: {string.Join(", ", woodCollected)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {count} branches left.");
            }

            PrintingMatrix(matrix, size);
        }

        static void MakeMove(int size, char[,] matrix, List<char> woodCollected, string direction, ref int beaverRow, ref int beaverCol)
        {
            switch (direction)
            {
                case "up":

                    if (LocationIsValid(beaverRow - 1, beaverCol, size))
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        beaverRow--;

                        if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';

                            if (beaverRow == size - 1 || beaverRow == 0
                                || beaverCol == size - 1 || beaverCol == 0)
                            {
                                if (matrix[size - 1, beaverCol] != '-')
                                {
                                    woodCollected.Add(matrix[size - 1, beaverCol]);
                                }

                                matrix[size - 1, beaverCol] = 'B';
                            }
                            else
                            {
                                if (matrix[0, beaverCol] != '-')
                                {
                                    woodCollected.Add(matrix[0, beaverCol]);
                                }

                                matrix[0, beaverCol] = 'B';
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == '-')
                        {
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            woodCollected.Add(matrix[beaverRow, beaverCol]);
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        if (woodCollected.Count > 0)
                        {
                            woodCollected.RemoveAt(woodCollected.Count - 1);
                        }
                    }

                    break;

                case "down":

                    if (LocationIsValid(beaverRow + 1, beaverCol, size))
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        beaverRow++;

                        if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';

                            if (beaverRow == size - 1 || beaverRow == 0
                                || beaverCol == size - 1 || beaverCol == 0)
                            {
                                if (matrix[0, beaverCol] != '-')
                                {
                                    woodCollected.Add(matrix[0, beaverCol]);
                                }

                                matrix[0, beaverCol] = 'B';
                            }
                            else
                            {
                                if (matrix[size - 1, beaverCol] != '-')
                                {
                                    woodCollected.Add(matrix[size - 1, beaverCol]);
                                }

                                matrix[size - 1, beaverCol] = 'B';
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == '-')
                        {
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            woodCollected.Add(matrix[beaverRow, beaverCol]);
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        if (woodCollected.Count > 0)
                        {
                            woodCollected.RemoveAt(woodCollected.Count - 1);
                        }
                    }

                    break;

                case "left":

                    if (LocationIsValid(beaverRow, beaverCol - 1, size))
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        beaverCol--;

                        if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';

                            if (beaverRow == size - 1 || beaverRow == 0
                                || beaverCol == size - 1 || beaverCol == 0)
                            {
                                if (matrix[beaverRow, size - 1] != '-')
                                {
                                    woodCollected.Add(matrix[beaverRow, size - 1]);
                                }

                                matrix[beaverRow, size - 1] = 'B';
                            }
                            else
                            {
                                if (matrix[beaverRow, 0] != '-')
                                {
                                    woodCollected.Add(matrix[beaverRow, 0]);
                                }

                                matrix[beaverRow, 0] = 'B';
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == '-')
                        {
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            woodCollected.Add(matrix[beaverRow, beaverCol]);
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        if (woodCollected.Count > 0)
                        {
                            woodCollected.RemoveAt(woodCollected.Count - 1);
                        }
                    }

                    break;

                case "right":

                    if (LocationIsValid(beaverRow, beaverCol + 1, size))
                    {
                        matrix[beaverRow, beaverCol] = '-';
                        beaverCol++;

                        if (matrix[beaverRow, beaverCol] == 'F')
                        {
                            matrix[beaverRow, beaverCol] = '-';

                            if (beaverRow == size - 1 || beaverRow == 0
                                || beaverCol == size - 1 || beaverCol == 0)
                            {
                                if (matrix[beaverRow, 0] != '-')
                                {
                                    woodCollected.Add(matrix[beaverRow, 0]);
                                }

                                matrix[beaverRow, 0] = 'B';
                            }
                            else
                            {
                                if (matrix[beaverRow, size - 1] != '-')
                                {
                                    woodCollected.Add(matrix[beaverRow, size - 1]);
                                }

                                matrix[beaverRow, size - 1] = 'B';
                            }
                        }
                        else if (matrix[beaverRow, beaverCol] == '-')
                        {
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                        else
                        {
                            woodCollected.Add(matrix[beaverRow, beaverCol]);
                            matrix[beaverRow, beaverCol] = 'B';
                        }
                    }
                    else
                    {
                        if (woodCollected.Count > 0)
                        {
                            woodCollected.RemoveAt(woodCollected.Count - 1);
                        }
                    }

                    break;
            }
        }
        static int[] LocatingBeaver(char[,] matrix, int size)
        {
            int[] location = new int[2];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        location[0] = row;
                        location[1] = col;
                    }
                }
            }

            return location;
        }
        static bool LocationIsValid(int row, int col, int size)
        {
            if (row >= 0 && row < size
                && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }
        static int IsWoodCollected(int size, char[,] matrix)
        {
            int count = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] != 'F'
                        && matrix[row, col] != 'B'
                        && matrix[row, col] != '-')
                    {
                        count++;
                    }
                }
            }

            return count;
        }
        static void PrintingMatrix(char[,] matrix, int size)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}
