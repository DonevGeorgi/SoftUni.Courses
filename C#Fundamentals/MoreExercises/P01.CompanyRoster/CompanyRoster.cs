using System;
using System.Collections.Generic;
using System.Linq;

namespace P01.CompanyRoster
{
    internal class CompanyRoster
    {
        static void Main()
        {
            List<Employee> employees = new List<Employee>();

            InitializingEmployees(employees);

            string bestDepartment = BestAverageSalary(employees);
            PrintingAndSortingEmployee(employees, bestDepartment);

        }

        static void InitializingEmployees(List<Employee> employees)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                string[] inputArgs = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string employeeName = inputArgs[0];
                double employeeSalary = double.Parse(inputArgs[1]);
                string DepartmentOfTheEmployee = inputArgs[2];

                Employee employee = new Employee(employeeName, employeeSalary, DepartmentOfTheEmployee);
                employees.Add(employee);
            }
        }
        static string BestAverageSalary(List<Employee> employees)
        {
            double bestAverageSalary = 0;

            string bestDepartment = string.Empty;

            for (int i = 0; i < employees.Count; i++)
            {
                string currentDepartment = employees[i].Department;
                int count = 0;
                double averageSalary = 0;
                double totalSalary = 0;

                for (int k = 0; k < employees.Count; k++)
                {
                    if (employees[k].Department == currentDepartment)
                    {
                        totalSalary += employees[k].Salary;
                        count++;
                    }
                }

                averageSalary = totalSalary / count;

                if (bestAverageSalary < averageSalary)
                {
                    bestAverageSalary = averageSalary;
                    bestDepartment = currentDepartment;
                }
            }

            return bestDepartment;
        }
        static void PrintingAndSortingEmployee(List<Employee> employees, string bestDepartment)
        {
            List<Employee> sortedEmployees = new List<Employee>();

            foreach (Employee employee in employees)
            {
                if (employee.Department == bestDepartment)
                {
                    sortedEmployees.Add(employee);
                }
            }

            sortedEmployees = sortedEmployees
                .OrderByDescending(x => x.Salary)
                .ToList();


            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            foreach (Employee employee in sortedEmployees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }
        }

        public class Employee
        {
            public Employee(string name, double salary, string department)
            {
                this.Name = name;
                this.Salary = salary;
                this.Department = department;
            }

            public string Name { get; set; }
            public double Salary { get; set; }
            public string Department { get; set; }
        }
    }
}
