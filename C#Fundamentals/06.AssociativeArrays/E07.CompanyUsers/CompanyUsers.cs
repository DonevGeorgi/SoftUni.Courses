using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.CompanyUsers
{
    internal class CompanyUsers
    {
        static void Main()
        {
            Dictionary<string, List<string>> employeeData =
                new Dictionary<string, List<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);

                string nameOfCompany = inputArgs[0];
                string employeeId = inputArgs[1];

                if (!employeeData.ContainsKey(nameOfCompany))
                {
                    employeeData[nameOfCompany] = new List<string>();
                }

                bool isPresent = IsPresentId(employeeData[nameOfCompany], employeeId);

                if (!isPresent)
                {
                    employeeData[nameOfCompany].Add(employeeId);
                }
            }

            foreach (var employee in employeeData)
            {
                string nameOfEmployee = employee.Key;
                List<string> employeeList = employee.Value;

                Console.WriteLine($"{nameOfEmployee}");

                foreach (string employeeId in employeeList)
                {
                    Console.WriteLine($"-- {employeeId}");
                }
            }
        }

        static bool IsPresentId(List<string> employeeData, string employeeId)
        {
            foreach (var employee in employeeData)
            {
                bool isPresent = employee.Contains(employeeId);

                if (isPresent)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
