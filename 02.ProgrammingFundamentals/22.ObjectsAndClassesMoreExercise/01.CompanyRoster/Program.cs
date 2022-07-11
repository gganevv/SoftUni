using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            List<string> departments = new List<string>();
            string bestDepartment = string.Empty;
            double maxDepartmentAvgSalary = double.MinValue;

            int numberOfEmployees = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfEmployees; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                double salary = double.Parse(inputArgs[1]);
                string department = inputArgs[2];
                if (!departments.Contains(department))
                {
                    departments.Add(department);
                }
                employees.Add(new Employee(name, salary, department));
            }

            employees = employees.OrderByDescending(x => x.Salary).ToList();

            foreach (string department in departments)
            {
                double departmentTotalSalary = 0;
                int employeeCounter = 0;
                foreach (var employee in employees)
                {
                    if (employee.Department == department)
                    {
                        departmentTotalSalary += employee.Salary;
                        employeeCounter++;
                    }
                }
                departmentTotalSalary /= employeeCounter;
                if (maxDepartmentAvgSalary < departmentTotalSalary)
                {
                    maxDepartmentAvgSalary = departmentTotalSalary;
                    bestDepartment = department;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDepartment}");

            foreach (var employee in employees)
            {
                if (employee.Department == bestDepartment)
                {
                    Console.WriteLine(employee);
                }
            }
        }
    }
}
