using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PracticeField5._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            string[] listWhitCommands = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            int rows = size;
            int cols = size;

            int firstPlayerShips = 0;
            int secondPlayerShips = 0;

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

                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondPlayerShips++;
                    }
                }
            }

            int playerOneDestroyedShips = 0;
            int playerTwoDestroyedShips = 0;

            for (int i = 0; i < listWhitCommands.Length; i++)
            {
                int[] coordinates = listWhitCommands[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                int attackRow = coordinates[0];
                int attackCol = coordinates[1];

                if (IsValid(attackRow, attackCol, size))
                {
                    if (matrix[attackRow, attackCol] == '<')
                    {
                        matrix[attackRow, attackCol] = 'X';
                        playerOneDestroyedShips++;
                    }
                    else if (matrix[attackRow, attackCol] == '>')
                    {
                        matrix[attackRow, attackCol] = 'X';
                        playerTwoDestroyedShips++;
                    }
                    else if (matrix[attackRow, attackCol] == '#')
                    {
                        // up-left
                        if (IsValid(attackRow - 1, attackCol - 1, size))
                        {
                            if (matrix[attackRow - 1, attackCol - 1] == '<')
                            {
                                matrix[attackRow - 1, attackCol - 1] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow - 1, attackCol - 1] == '>')
                            {
                                matrix[attackRow - 1, attackCol - 1] = 'X';
                                playerTwoDestroyedShips++;
                            }
                        }

                        // up
                        if (IsValid(attackRow - 1, attackCol, size))
                        {
                            if (matrix[attackRow - 1, attackCol] == '<')
                            {
                                matrix[attackRow - 1, attackCol] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow - 1, attackCol] == '>')
                            {
                                matrix[attackRow - 1, attackCol] = 'X';
                                playerTwoDestroyedShips++;
                            }
                        }

                        // up-right
                        if (IsValid(attackRow - 1, attackCol + 1, size))
                        {
                            if (matrix[attackRow - 1, attackCol + 1] == '<')
                            {
                                matrix[attackRow - 1, attackCol + 1] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow - 1, attackCol + 1] == '>')
                            {
                                matrix[attackRow - 1, attackCol + 1] = 'X';
                                playerTwoDestroyedShips++;
                            }
                        }

                        // left
                        if (IsValid(attackRow, attackCol - 1, size))
                        {
                            if (matrix[attackRow, attackCol - 1] == '<')
                            {
                                matrix[attackRow, attackCol - 1] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow, attackCol - 1] == '>')
                            {
                                matrix[attackRow, attackCol - 1] = 'X';
                                playerTwoDestroyedShips++;
                            }
                        }

                        // right
                        if (IsValid(attackRow, attackCol + 1, size))
                        {
                            if (matrix[attackRow, attackCol + 1] == '<')
                            {
                                matrix[attackRow, attackCol + 1] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow, attackCol + 1] == '>')
                            {
                                matrix[attackRow, attackCol + 1] = 'X';
                                playerTwoDestroyedShips++;
                            }
                        }

                        // down-left
                        if (IsValid(attackRow + 1, attackCol - 1, size))
                        {
                            if (matrix[attackRow + 1, attackCol - 1] == '<')
                            {
                                matrix[attackRow + 1, attackCol - 1] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow + 1, attackCol - 1] == '>')
                            {
                                matrix[attackRow + 1, attackCol - 1] = 'X';
                                playerTwoDestroyedShips++;
                            }
                        }

                        // down
                        if (IsValid(attackRow + 1, attackCol, size))
                        {
                            if (matrix[attackRow + 1, attackCol] == '<')
                            {
                                matrix[attackRow + 1, attackCol] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow + 1, attackCol] == '>')
                            {
                                matrix[attackRow + 1, attackCol] = 'X';
                                playerTwoDestroyedShips++;
                            }

                        }

                        // down-right
                        if (IsValid(attackRow + 1, attackCol + 1, size))
                        {
                            if (matrix[attackRow + 1, attackCol + 1] == '<')
                            {
                                matrix[attackRow + 1, attackCol + 1] = 'X';
                                playerOneDestroyedShips++;
                            }
                            else if (matrix[attackRow + 1, attackCol + 1] == '>')
                            {
                                matrix[attackRow + 1, attackCol + 1] = 'X';
                                playerTwoDestroyedShips++;
                            }

                        }

                        matrix[attackRow, attackCol] = 'X';
                    }

                    if (firstPlayerShips <= playerOneDestroyedShips)
                    {
                        Console.WriteLine($"Player Two has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                        return;
                    }
                    else if (secondPlayerShips <= playerTwoDestroyedShips)
                    {
                        Console.WriteLine($"Player One has won the game! {playerOneDestroyedShips + playerTwoDestroyedShips} ships have been sunk in the battle.");
                        return;
                    }
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShips - playerOneDestroyedShips} ships left. Player Two has {secondPlayerShips - playerTwoDestroyedShips} ships left.");
        }
        static bool IsValid(int row, int col, int size)
        {
            if (row >= 0 && row < size
                    && col >= 0 && col < size)
            {
                return true;
            }

            return false;
        }

    }
}

