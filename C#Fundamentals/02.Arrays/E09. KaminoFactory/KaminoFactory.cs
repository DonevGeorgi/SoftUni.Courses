using System;
using System.Linq;

namespace E09.KaminoFactory
{
    internal class KaminoFactory
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());


            int bestEqualityIndex = 0;
            int[] bestDnaSequence = new int[n];
            int indexSum = 0;
            int bestIndexSum = 0;
            int numberOfSample = 0;
            int numberOfBestSample = 0;
            int indexEqualityStart = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] data = input
                    .Split("!", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int equalityIndex = 0;
                numberOfSample++;

                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] == 1)
                    {
                        equalityIndex++;
                    }
                    else
                    {
                        equalityIndex = 0;
                    }

                    if (equalityIndex > bestEqualityIndex)
                    {
                        bestEqualityIndex = equalityIndex;
                        bestDnaSequence = data;
                        numberOfBestSample = numberOfSample;
                        bestIndexSum = data.Sum();

                        indexEqualityStart = i - equalityIndex + 1;
                    }
                    else if (equalityIndex == bestEqualityIndex && indexEqualityStart > i - equalityIndex + 1)
                    {
                        bestDnaSequence = data;
                        numberOfBestSample = numberOfSample;
                        indexEqualityStart = i - equalityIndex + 1;
                        bestIndexSum = data.Sum();
                    }
                    else if (equalityIndex == bestEqualityIndex && indexEqualityStart == i - equalityIndex + 1)
                    {
                        indexSum = data.Sum();

                        if (indexSum > bestIndexSum)
                        {
                            bestIndexSum = indexSum;
                            bestDnaSequence = data;
                            numberOfBestSample = numberOfSample;
                            indexEqualityStart = i - equalityIndex + 1;
                        }

                    }
                }
            }

            Console.WriteLine($"Best DNA sample {numberOfBestSample} with sum: {bestIndexSum}.");
            Console.WriteLine(String.Join(" ", bestDnaSequence));

        }
    }
}
