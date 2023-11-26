using System.Security.Cryptography.X509Certificates;

int n = int.Parse(Console.ReadLine());

string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Func<string, int, bool> isNecessaryLength = (name, n) => name.Sum(ch => ch) >= n;

Func<string[], Func<string, int, bool>, string> serchingTheFirstName = (names, isNecessaryLength) => names.First(x => isNecessaryLength(x, n));

Console.WriteLine(serchingTheFirstName(names, isNecessaryLength));