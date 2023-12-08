using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();

                jaggedArray[row] = new char[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    jaggedArray[row][col] = rowData[col];
                }
            }

            int collectedTokens = 0;
            int opponentCollectedTokens = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (inputArray[0] == "Find")
                {
                    int row = int.Parse(inputArray[1]);
                    int col = int.Parse(inputArray[2]);

                    if (IsValid(jaggedArray, row, col, rows))
                    {
                        if (jaggedArray[row][col] == 'T')
                        {
                            collectedTokens++;
                            jaggedArray[row][col] = '-';
                        }
                    }

                }
                else if (inputArray[0] == "Opponent")
                {
                    int row = int.Parse(inputArray[1]);
                    int col = int.Parse(inputArray[2]);
                    string direction = inputArray[3];

                    if (IsValid(jaggedArray, row, col, rows))
                    {
                        int count = 0;

                        switch (direction)
                        {

                            case "up":

                                for (int r = row; r >= 0; r--)
                                {
                                    if (!IsValid(jaggedArray, r, col, rows))
                                    {
                                        break;
                                    }

                                    if (jaggedArray[r][col] == 'T')
                                    {
                                        opponentCollectedTokens++;
                                        jaggedArray[r][col] = '-';
                                    }

                                    if (count == 3)
                                    {
                                        break;
                                    }

                                    count++;
                                }

                                break;

                            case "down":

                                for (int r = row; r < rows; r++)
                                {
                                    if (!IsValid(jaggedArray, r, col, rows))
                                    {
                                        break;
                                    }

                                    if (jaggedArray[r][col] == 'T')
                                    {
                                        opponentCollectedTokens++;
                                        jaggedArray[r][col] = '-';
                                    }

                                    if (count == 3)
                                    {
                                        break;
                                    }

                                    count++;
                                }

                                break;

                            case "left":

                                for (int c = col; c >= 0; c--)
                                {
                                    if (!IsValid(jaggedArray, row, c, rows))
                                    {
                                        break;
                                    }

                                    if (jaggedArray[row][c] == 'T')
                                    {
                                        opponentCollectedTokens++;
                                        jaggedArray[row][c] = '-';
                                    }

                                    if (count == 3)
                                    {
                                        break;
                                    }

                                    count++;
                                }

                                break;

                            case "right":

                                for (int c = col; c < jaggedArray[row].Length; c++)
                                {
                                    if (!IsValid(jaggedArray, row, c, rows))
                                    {
                                        break;
                                    }

                                    if (jaggedArray[row][c] == 'T')
                                    {
                                        opponentCollectedTokens++;
                                        jaggedArray[row][c] = '-';
                                    }

                                    if (count == 3)
                                    {
                                        break;
                                    }

                                    count++;
                                }

                                break;
                        }

                    }

                }
            }

            PrintJaggedArray(rows, jaggedArray);
            Console.WriteLine($"Collected tokens: {collectedTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentCollectedTokens}");
        }

        static bool IsValid(char[][] jaggedArray, int row, int col, int size)
        {
            if (row >= 0 && row < size
                && col >= 0 && col < jaggedArray[row].Length)
            {
                return true;
            }

            return false;
        }
        static void PrintJaggedArray(int rows, char[][] jaggedArray)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write($"{jaggedArray[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}

