
using P03.GenericSwapMethodStrings;

Box<string> box = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    box.Add(Console.ReadLine());
}

int[] indexes = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToArray();

box.Swap(indexes[0], indexes[1]);

Console.WriteLine(box.ToString());