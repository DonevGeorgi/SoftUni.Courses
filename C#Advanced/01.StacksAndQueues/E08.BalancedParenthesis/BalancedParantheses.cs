using System;
using System.Collections.Generic;

namespace P08.BalancedParantheses
{
    internal class BalancedParantheses
    {
        static void Main()
        {
            string input = Console.ReadLine();

            Stack<char> parantheses = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    parantheses.Push(input[i]);
                }
                else if (input[i] == '[')
                {
                    parantheses.Push(input[i]);
                }
                else if (input[i] == '(')
                {
                    parantheses.Push(input[i]);
                }
                else if (input[i] == ')' && parantheses.Count > 0)
                {
                    if (parantheses.Pop() != '(')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == '}' && parantheses.Count > 0)
                {
                    if (parantheses.Pop() != '{')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else if (input[i] == ']' && parantheses.Count > 0)
                {
                    if (parantheses.Pop() != '[')
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("NO");
                    return;
                }
            }


            Console.WriteLine("YES");
        }


    }
}

