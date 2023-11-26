List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

string input = string.Empty;
while ((input = Console.ReadLine()) != "Party!")
{
    string[] inputArgs = input
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    if (inputArgs[0] == "Remove")
    {
        names.RemoveAll(IsTrue(inputArgs[1], inputArgs[2]));
    }
    else if (inputArgs[0] == "Double")
    {
        List<string> peoples = names.FindAll(IsTrue(inputArgs[1], inputArgs[2]));

        foreach (var people in peoples)
        {
            names.Insert(names.FindIndex(p => p == people), people);
        }
    }
}

if (names.Any())
{
    Console.WriteLine($"{String.Join(", ", names)} are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}

static Predicate<string> IsTrue(string operation, string value)
{
    switch (operation)
    {
        case "StartsWith":
            return p => p.StartsWith(value);
        case "EndsWith":
            return p => p.EndsWith(value);
        case "Length":
            return p => p.Length == int.Parse(value);
        default:
            return default;
    }
};