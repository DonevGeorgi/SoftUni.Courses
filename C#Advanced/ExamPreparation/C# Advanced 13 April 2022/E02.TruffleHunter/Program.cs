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
            int forestSize = int.Parse(Console.ReadLine());

            int rows = forestSize;
            int cols = forestSize;

            char[,] forest = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    forest[row, col] = rowData[col];
                }
            }

            Dictionary<string, int> trufflesCollected =
                new Dictionary<string, int>();

            trufflesCollected["Black truffle"] = 0;
            trufflesCollected["Summer truffle"] = 0;
            trufflesCollected["White truffle"] = 0;

            int truffleEatenByTheBoar = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArgs[0] == "Collect")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);

                    if (LocationIsValid(row, col, forestSize))
                    {
                        if (forest[row, col] == 'B')
                        {
                            trufflesCollected["Black truffle"]++;
                            forest[row, col] = '-';
                        }
                        else if (forest[row, col] == 'S')
                        {
                            trufflesCollected["Summer truffle"]++;
                            forest[row, col] = '-';
                        }
                        else if (forest[row, col] == 'W')
                        {
                            trufflesCollected["White truffle"]++;
                            forest[row, col] = '-';
                        }
                    }

                }
                else if (commandArgs[0] == "Wild_Boar")
                {
                    int row = int.Parse(commandArgs[1]);
                    int col = int.Parse(commandArgs[2]);
                    string direction = commandArgs[3];

                    //forest[row, col] = '-';
                    //truffleEatenByTheBoar++;

                    int count = 0;

                    switch (direction)
                    {
                        case "up":

                            for (int r = row; r >= 0; r--)
                            {
                                if (count % 2 == 0)
                                {
                                    if (forest[r, col] != '-')
                                    {
                                        forest[r, col] = '-';
                                        truffleEatenByTheBoar++;
                                    }
                                }

                                count++;
                            }

                            break;

                        case "down":

                            for (int r = row; r < forestSize; r++)
                            {
                                if (count % 2 == 0)
                                {
                                    if (forest[r, col] != '-')
                                    {
                                        forest[r, col] = '-';
                                        truffleEatenByTheBoar++;
                                    }
                                }

                                count++;
                            }

                            break;

                        case "left":

                            for (int c = col; c >= 0; c--)
                            {
                                if (count % 2 == 0)
                                {
                                    if (forest[row, c] != '-')
                                    {
                                        forest[row, c] = '-';
                                        truffleEatenByTheBoar++;
                                    }
                                }

                                count++;
                            }

                            break;

                        case "right":

                            for (int c = col; c < forestSize; c++)
                            {
                                if (count % 2 == 0)
                                {
                                    if (forest[row, c] != '-')
                                    {
                                        forest[row, c] = '-';
                                        truffleEatenByTheBoar++;
                                    }
                                }

                                count++;
                            }

                            break;
                    }

                }
            }

            Console.WriteLine($"Peter manages to harvest {trufflesCollected["Black truffle"]} black, {trufflesCollected["Summer truffle"]} summer, and {trufflesCollected["White truffle"]} white truffles.");
            Console.WriteLine($"The wild boar has eaten {truffleEatenByTheBoar} truffles.");
            PrintingMatrix(forest, forestSize);
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
        static void PrintingMatrix(char[,] matrix, int size)
        {
            List<char> rowData = new List<char>();

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    rowData.Add(matrix[row, col]);
                }

                Console.WriteLine(string.Join(" ", rowData));
                rowData.Clear();
            }
        }
    }
}
