using P03.GenericCountMethodStrings;

Box<string> box = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    box.Add(Console.ReadLine());
}

string stringForComparison = Console.ReadLine();

Console.WriteLine(box.Count(stringForComparison));