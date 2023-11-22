using System;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace P09.Miner
{
    internal class Miner
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            string[] commands = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            int rows = size;
            int cols = size;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                char[] rowData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            int currMove = 0;
            int coal = FindCoal(matrix, size);

            while (true)
            {
                string currComand = commands[currMove];

                int[] playerCoordinater = LocationOfPlayer(matrix, size);
                int playerRow = playerCoordinater[0];
                int playerCol = playerCoordinater[1];

                switch (currComand)
                {
                    case "left":
                        if (IsValid(playerRow, playerCol - 1, size))
                        {
                            matrix[playerRow, playerCol] = '*';

                            if (matrix[playerRow, playerCol - 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol - 1})");
                                return;
                            }
                            if (matrix[playerRow, playerCol - 1] == 'c')
                            {
                                coal--;
                            }

                            matrix[playerRow, playerCol - 1] = 's';
                            playerRow = playerRow;
                            playerCol = playerCol - 1;
                        }
                        break;

                    case "right":
                        if (IsValid(playerRow, playerCol + 1, size))
                        {
                            matrix[playerRow, playerCol] = '*';

                            if (matrix[playerRow, playerCol + 1] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow}, {playerCol + 1})");
                                return;
                            }
                            if (matrix[playerRow, playerCol + 1] == 'c')
                            {
                                coal--;
                            }

                            matrix[playerRow, playerCol + 1] = 's';
                            playerRow = playerRow;
                            playerCol = playerCol + 1;
                        }
                        break;

                    case "down":
                        if (IsValid(playerRow + 1, playerCol, size))
                        {
                            matrix[playerRow, playerCol] = '*';

                            if (matrix[playerRow + 1, playerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow + 1}, {playerCol})");
                                return;
                            }
                            if (matrix[playerRow + 1, playerCol] == 'c')
                            {
                                coal--;
                            }

                            matrix[playerRow + 1, playerCol] = 's';
                            playerRow = playerRow + 1;
                            playerCol = playerCol;
                        }
                        break;

                    case "up":
                        if (IsValid(playerRow - 1, playerCol, size))
                        {
                            matrix[playerRow, playerCol] = '*';

                            if (matrix[playerRow - 1, playerCol] == 'e')
                            {
                                Console.WriteLine($"Game over! ({playerRow - 1}, {playerCol})");
                                return;
                            }
                            if (matrix[playerRow - 1, playerCol] == 'c')
                            {
                                coal--;
                            }

                            matrix[playerRow - 1, playerCol] = 's';
                            playerRow = playerRow - 1;
                            playerCol = playerCol;
                        }
                        break;
                }

                if (coal == 0)
                {
                    Console.WriteLine($"You collected all coals! ({playerRow}, {playerCol})");
                    return;
                }

                currMove++;

                if (currMove == commands.Length)
                {
                    Console.WriteLine($"{coal} coals left. ({playerRow}, {playerCol})");
                    return;
                }
            }
        }

        static bool IsValid(int row, int col, int size)
        {
            if (row < size && row >= 0
                && col < size && col >= 0)
            {
                return true;
            }

            return false;
        }
        static int FindCoal(char[,] matrix, int size)
        {
            int coal = 0;

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coal++;
                    }
                }
            }

            return coal;
        }
        static int[] LocationOfPlayer(char[,] matrix, int size)
        {
            int[] playerCoordinates = new int[2];

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        playerCoordinates[0] = row;
                        playerCoordinates[1] = col;

                        return playerCoordinates;
                    }
                }
            }

            return playerCoordinates;
        }
    }
}
