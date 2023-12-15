//Do not remove because of judge. Don't put in folders because of the namespace.
namespace PersonInfo;

public class StartUp
{
    static void Main()
    {
        List<IBuyer> buyers = new();
        List<IPerson> persons = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokkens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (tokkens.Length == 3)
            {
                IBuyer rebel = new Rebel(tokkens[0], int.Parse(tokkens[1]), tokkens[2]);
                buyers.Add(rebel);
            }
            else if (tokkens.Length == 4)
            {
                IBuyer citizen = new Citizen(tokkens[0], int.Parse(tokkens[1]), tokkens[2], tokkens[3]);
                buyers.Add(citizen);
            }
        }

        string input = string.Empty;

        while ((input = Console.ReadLine()) != "End")
        {
            foreach (IBuyer buyer in buyers)
            {
                if (buyer.Name == input)
                {
                    buyer.BuyFood();
                }
            }
        }

        Console.WriteLine(buyers.Sum(f => f.Food));
    }
}