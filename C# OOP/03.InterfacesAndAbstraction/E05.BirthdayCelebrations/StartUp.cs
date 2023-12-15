//Do not remove because of judge. Don't put in folders because of the namespace.
using P05.BirthdayCelebrations;

namespace PersonInfo;

public class StartUp
{
    static void Main()
    {
        List<IBirthable> allPassedThePost = new();

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs[0] == "Citizen")
            {
                Citizen currPassing = new(inputArgs[1], int.Parse(inputArgs[2]), inputArgs[3], inputArgs[4]);
                allPassedThePost.Add(currPassing);
            }
            else if (inputArgs[0] == "Pet")
            {
                Pet currPassing = new(inputArgs[1], inputArgs[2]);
                allPassedThePost.Add(currPassing);
            }
            else if (inputArgs[0] == "Robot")
            {
                Robots currPassing = new(inputArgs[1], inputArgs[2]);
            }
        }

        string birthYear = Console.ReadLine();

        foreach (IBirthable currCheck in allPassedThePost)
        {
            if (currCheck.Birthdate.EndsWith(birthYear))
            {
                Console.WriteLine(currCheck.Birthdate);
            }
        }
    }
}