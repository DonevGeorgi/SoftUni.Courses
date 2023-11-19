﻿using System;
using System.Text;

namespace P07.StringsExplosions
{
    internal class StringsExplosions
    {
        static void Main()
        {
            string field = Console.ReadLine();

            int bomb = 0;

            for (int i = 0; i < field.Length; i++)
            {

                if (bomb > 0 && field[i] != '>')
                {
                    field = field.Remove(i, 1);
                    bomb--;
                    i--;
                }
                else if (field[i] == '>')
                {
                    bomb += int.Parse(field[i + 1].ToString());
                }
            }

            Console.WriteLine(field);
        }
    }
}