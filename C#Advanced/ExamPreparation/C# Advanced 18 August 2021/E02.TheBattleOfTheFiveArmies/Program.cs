using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int armor = int.Parse(Console.ReadLine());
            int size = int.Parse(Console.ReadLine());

            int rows = size;

            int armyRow = 0;
            int armyCol = 0;

            char[][] jaggedArray = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                string rowData = Console.ReadLine();

                jaggedArray[row] = new char[rowData.Length];

                for (int col = 0; col < rowData.Length; col++)
                {
                    jaggedArray[row][col] = rowData[col];

                    if (jaggedArray[row][col] == 'A')
                    {
                        armyRow = row;
                        armyCol = col;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                jaggedArray[armyRow][armyCol] = '-';

                jaggedArray[int.Parse(input[1])][int.Parse(input[2])] = 'O';


                switch (input[0])
                {
                    case "up": armyRow--; break;
                    case "down": armyRow++; break;
                    case "left": armyCol--; break;
                    case "right": armyCol++; break;
                }

                if (IsLocationValid(jaggedArray, armyRow, armyCol, size))
                {

                    if (jaggedArray[armyRow][armyCol] == 'M')
                    {
                        armor--;
                        jaggedArray[armyRow][armyCol] = '-';
                        Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
                        PrintingMatrix(jaggedArray, size);
                        return;
                    }
                    if (jaggedArray[armyRow][armyCol] == 'O')
                    {
                        armor -= 2;
                    }
                }
                else
                {
                    switch (input[0])
                    {
                        case "up": armyRow++; break;
                        case "down": armyRow--; break;
                        case "left": armyCol++; break;
                        case "right": armyCol--; break;
                    }

                }

                jaggedArray[armyRow][armyCol] = 'A';
                armor--;

                if (armor <= 0)
                {
                    jaggedArray[armyRow][armyCol] = 'X';
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    PrintingMatrix(jaggedArray, size);
                    return;
                }

            }
        }

        static bool IsLocationValid(char[][] jaggedArray, int row, int col, int size)
        {
            if (row >= 0 && col >= 0
                && row < size && col < jaggedArray[row].Length)
            {
                return true;
            }

            return false;
        }
        static void PrintingMatrix(char[][] jaggedArray, int size)
        {
            for (int row = 0; row < size; row++)
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

