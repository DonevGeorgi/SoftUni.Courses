using System;

namespace _07.Shopping
{
    internal class Shopping
    {
        static void Main(string[] args)
        {
            double availableBudget = double.Parse(Console.ReadLine());
            int gpuNum = int.Parse(Console.ReadLine());
            int cpuNum = int.Parse(Console.ReadLine());
            int ramSlotNum = int.Parse(Console.ReadLine());

            double totalForGPUs = gpuNum * 250;

            double cpuSinglePrice = 0.35 * totalForGPUs;
            double totalForCPUs = cpuNum * cpuSinglePrice;

            double ramSinglePrice = 0.1 * totalForGPUs;
            double totalForRAM = ramSlotNum * ramSinglePrice;

            double totalForAll = totalForGPUs + totalForCPUs + totalForRAM;

            if (gpuNum > cpuNum)
            {
                double discount = 0.15 * totalForAll;

                totalForAll -= discount;
            }

            if (availableBudget >= totalForAll)
            {
                Console.WriteLine($"You have {availableBudget - totalForAll:F2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {totalForAll - availableBudget:F2} leva more!");
            }
        }
    }
}
