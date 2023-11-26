int range = int.Parse(Console.ReadLine());

int[] numbersDev = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(n => int.Parse(n))
    .ToArray();

int[] numberArray = Enumerable.Range(1, range).ToArray();

Func<int, int, bool> match = (num1, num2) => num1 % num2 == 0 ? true : false;

Func<int[], int[], Func<int, int, bool>, List<int>> acumulateList = (numbersArray, numbersDev, match) =>
{
    List<int> newArray = new List<int>();

    for (int i = 0; i < numberArray.Length; i++)
    {
        int count = 0;

        for (int k = 0; k < numbersDev.Length; k++)
        {
            if (match(numberArray[i], numbersDev[k]))
            {
                count++;

                if (count == numbersDev.Length)
                {
                    newArray.Add(numberArray[i]);
                }
            }
        }
    }

    return newArray;
};

List<int> result = new(acumulateList(numberArray, numbersDev, match));

Console.WriteLine(string.Join(" ", result));