using SoftUni.Data;
using System.Text;
using SoftUni.Models;

namespace SoftUni;

public class StartUp
{
    static void Main(string[] args)
    {
        SoftUniContext dBcontext = new SoftUniContext();

        //Problem 03 Employees Full Information
        //string result = GetEmployeesFullInformation(dBcontext);

        //Problem 04 Employees With Salary Over 50 000
        //string result = GetEmployeesWithSalaryOver50000(dBcontext);

        //Problem 05 Employees from Research and Development
        //string result = GetEmployeesFromResearchAndDevelopment(dBcontext);

        //Problem 06 Adding a New Address and Updating Employee
        string result = AddNewAddressToEmployee(dBcontext);

        Console.WriteLine(result);
    }

    //Problem 03 Employees Full Information
    public static string GetEmployeesFullInformation(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();
        var employees = context.Employees
            .OrderBy(e => e.EmployeeId)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:f2}");
        }
        return sb.ToString().TrimEnd();
    }

    //Problem 04 Employees With Salary Over 50 000
    public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Where(e => e.Salary > 50000)
            .Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
        }


        return sb.ToString().TrimEnd();
    }

    //Problem 05 Employees from Research and Development
    public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var empleyees = context.Employees
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                Department = e.Department.Name,
                e.Salary
            })
            .ToArray();

        foreach (var e in empleyees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department} - ${e.Salary:f2}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 06 Adding a New Address and Updating Employee
    public static string AddNewAddressToEmployee(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        Address address = new Address()
        {
            AddressText = "Vitoshka 15",
            TownId = 4
        };

        Employee employee = context.Employees
            .FirstOrDefault(e => e.LastName == "Nakov")!;
        
        employee.Address = address;

        context.SaveChanges();

        var employees = context.Employees
            .OrderByDescending(e => e.AddressId)
            .Take(10)
            .Select(e => e.Address.AddressText)
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine(e);
        }

        return sb.ToString().TrimEnd();
    }
}