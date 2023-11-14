using System;
using System.Linq;

namespace E04.PasswordValidator
{
    internal class PasswordValidator
    {
        static void Main(string[] args)
        {
            //Input
            string password = Console.ReadLine();

            //Method for contain 6 – 10 characters
            bool containChar = PasswordLenght(password);

            //Method for ontain only letters and digits
            bool onlyLatters = OnlyLattersAndChar(password);

            //Method for contain at least 2 digits
            bool containDigits = ContainTwoDigits(password);

            //Output
            IsPasswordValid(containChar, onlyLatters, containDigits);
        }

        static bool PasswordLenght(string password)
        {
            char[] pass = password.ToCharArray();

            if (pass.Length >= 6 && pass.Length <= 10)
            {
                return true;
            }

            return false;
        }

        static bool OnlyLattersAndChar(string password)
        {
            foreach (char character in password)
            {
                if (!Char.IsLetterOrDigit(character))
                {
                    return false;
                }
            }

            return true;
        }

        static bool ContainTwoDigits(string password)
        {
            int isLatter = 0;

            foreach (var character in password)
            {
                if (char.IsDigit(character))
                {
                    isLatter++;
                }
            }

            if (isLatter >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void IsPasswordValid(bool passLenght, bool charAndLattersOnly, bool containDigits)
        {
            if (!passLenght)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            if (!charAndLattersOnly)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }

            if (!containDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            else if (passLenght && charAndLattersOnly && containDigits)
            {
                Console.WriteLine("Password is valid");
            }
        }
    }
}
