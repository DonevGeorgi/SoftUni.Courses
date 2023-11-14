using System;

namespace E03.CharactersInRange
{
    internal class CharactersInRange
    {
        static void Main(string[] args)
        {
            //input
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());

            //Swapping Method
            if (firstCharacter > secondCharacter)
            {
                char a = firstCharacter;

                firstCharacter = secondCharacter;

                secondCharacter = a;
            }

            //Using Method
            AllCharacterInRange(firstCharacter, secondCharacter);
        }

        static void AllCharacterInRange(char firstChar, char secondChar)
        {


            for (int i = firstChar; i < secondChar; i++)
            {
                if (i == firstChar)
                {
                    continue;
                }

                Console.Write($"{(char)i} ");
            }
        }
    }
}
