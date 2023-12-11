using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mariosLives = int.Parse(Console.ReadLine());
            int rows = int.Parse(Console.ReadLine());

            char[][] jaggedArray = new char[rows][];

            int marioRow = 0;
            int marioCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                jaggedArray[row] = new char[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    jaggedArray[row][col] = rowData[col];

                    if (jaggedArray[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                jaggedArray[marioRow][marioCol] = '-';

                jaggedArray[int.Parse(input[1])][int.Parse(input[2])] = 'B';

                switch (input[0])
                {
                    case "W": marioRow--; break;
                    case "S": marioRow++; break;
                    case "A": marioCol--; break;
                    case "D": marioCol++; break;
                }

                if (IsCoordinatesValid(jaggedArray, marioRow, marioCol, rows))
                {
                    if (jaggedArray[marioRow][marioCol] == 'P')
                    {
                        mariosLives--;
                        jaggedArray[marioRow][marioCol] = '-';
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {mariosLives}");
                        PrintJaggedArray(jaggedArray, rows);
                        return;
                    }
                    else if (jaggedArray[marioRow][marioCol] == 'B')
                    {
                        if (mariosLives - 2 <= 0)
                        {
                            jaggedArray[marioRow][marioCol] = 'X';
                            Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                            PrintJaggedArray(jaggedArray, rows);
                            return;
                        }

                        mariosLives -= 2;
                    }
                }
                else
                {
                    switch (input[0])
                    {
                        case "W": marioRow++; break;
                        case "S": marioRow--; break;
                        case "A": marioCol++; break;
                        case "D": marioCol--; break;
                    }
                }

                jaggedArray[marioRow][marioCol] = 'M';
                mariosLives--;

                if (mariosLives <= 0)
                {
                    jaggedArray[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    PrintJaggedArray(jaggedArray, rows);
                    return;
                }
            }

        }


        static bool IsCoordinatesValid(char[][] jaggedArray, int row, int col, int size)
        {
            if (row >= 0 && col >= 0
                && row < size && col < jaggedArray[row].Length)
            {
                return true;
            }

            return false;
        }
        static void PrintJaggedArray(char[][] jaggedArray, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jaggedArray[row].Length; col++)
                {
                    Console.Write(jaggedArray[row][col]);
                }

                Console.WriteLine();
            }
        }
    }
}

