int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string[], int, List<string>> sortingByNameLength = (names, length) =>
{
    List<string> sortedNames = new List<string>();

    foreach (var name in names)
    {
        if (name.Length <= length)
        {
            sortedNames.Add(name);
        }
    }

    return sortedNames;
};

List<string> results = new(sortingByNameLength(names, n));

foreach (var result in results)
{
    Console.WriteLine(result);
}