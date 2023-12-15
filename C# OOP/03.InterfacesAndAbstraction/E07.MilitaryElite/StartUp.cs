//Do not remove because of judge. Don't put in folders because of the namespace.
using PersonInfo.Models.Classes;
using PersonInfo.Models.Enums;
using PersonInfo.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace PersonInfo;

public class StartUp
{
    static void Main()
    {
        try
        {
            Dictionary<int, ISoldier> soldiers = new();

            ISoldier soldier = null;
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int id = int.Parse(inputArgs[1]);
                string firstName = inputArgs[2];
                string lastName = inputArgs[3];

                if (inputArgs[0] == "Private")
                {
                    soldier = GetPrivate(id, firstName, lastName, decimal.Parse(inputArgs[4]));
                }
                else if (inputArgs[0] == "LieutenantGeneral")
                {
                    soldier = GetLieutenantGeneral(soldiers, id, firstName, lastName, decimal.Parse(inputArgs[4]), inputArgs);
                }
                else if (inputArgs[0] == "Engineer")
                {
                    soldier = GetEngineer(id, firstName, lastName, decimal.Parse(inputArgs[4]), inputArgs);
                }
                else if (inputArgs[0] == "Commando")
                {
                    soldier = GetCommando(id, firstName, lastName, decimal.Parse(inputArgs[4]), inputArgs);
                }
                else if (inputArgs[0] == "Spy")
                {
                    soldier = GetSpy(id, firstName, lastName, int.Parse(inputArgs[4]));
                }

                soldiers.Add(id, soldier);
            }

            foreach (var currSoldier in soldiers)
            {
                Console.WriteLine(currSoldier.Value.ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static ISoldier GetPrivate(int id, string firstName, string lastName, decimal slary)
        => new Private(id, firstName, lastName, slary);
    private static ISoldier GetLieutenantGeneral(Dictionary<int, ISoldier> soldiers, int id, string firstName, string lastName, decimal salary, string[] inputArgs)
    {
        List<IPrivate> privates = new();

        for (int i = 5; i < inputArgs.Length; i++)
        {
            int soldierId = int.Parse(inputArgs[i]);
            IPrivate soldier = (IPrivate)soldiers[soldierId];
            privates.Add(soldier);
        }

        return new LieutenantGeneral(id, firstName, lastName, salary, privates);
    }
    private static ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
    {

        bool isValidCorps = Enum.TryParse<Corps>(inputArgs[5], out Corps corps);

        if (!isValidCorps)
        {
            throw new Exception();
        }

        List<IRepair> repairs = new();

        for (int i = 6; i < inputArgs.Length; i += 2)
        {
            string partName = inputArgs[i];
            int hoursWorked = int.Parse(inputArgs[i + 1]);

            IRepair repair = new Repair(partName, hoursWorked);

            repairs.Add(repair);
        }

        return new Engineer(id, firstName, lastName, salary, corps, repairs);
    }
    private static ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] inputArgs)
    {
        bool isValidCorps = Enum.TryParse<Corps>(inputArgs[5], out Corps corps);

        if (!isValidCorps)
        {
            throw new Exception();
        }

        List<IMission> missions = new();

        for (int i = 6; i < inputArgs.Length; i += 2)
        {
            string missionName = inputArgs[i];
            string missionState = inputArgs[i + 1];

            bool isValidMissionState = Enum.TryParse<State>(missionState, out State state);

            if (!isValidMissionState)
            {
                continue;
            }

            IMission mission = new Mission(missionName, state);

            missions.Add(mission);

        }

        return new Commando(id, firstName, lastName, salary, corps, missions);
    }
    private static ISoldier GetSpy(int id, string firstName, string lastName, int codeNumber)
    {
        return new Spy(id, firstName, lastName, codeNumber);
    }
}
