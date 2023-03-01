using SoftUni.Data;
using System.Text;
using SoftUni.Models;
using System.Globalization;

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
        //string result = AddNewAddressToEmployee(dBcontext);

        //Problem 07 Get Employees In Period
        //string result = GetEmployeesInPeriod(dBcontext);

        //Problem 08 Addresses by Town
        //string result = GetAddressesByTown(dBcontext);

        //Problem 09 Employee 147
        //string result = GetEmployee147(dBcontext);

        //Problem 10 Departments with More Than 5 Employees
        string result = GetDepartmentsWithMoreThan5Employees(dBcontext);

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

    //Problem 07 Get Employees In Period
    public static string GetEmployeesInPeriod(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employees = context.Employees
            .Take(10)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                ManagerFirstName = e.Manager.FirstName,
                ManagerLastName = e.Manager.LastName,
                Projects = e.EmployeesProjects
                .Where(ep => ep.Project.StartDate.Year >= 2001 &&
                ep.Project.StartDate.Year <= 2003)
                .Select(ep => new
                {
                    ProjectName = ep.Project.Name,
                    StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                    EndDate = ep.Project.EndDate.HasValue
                            ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                })
                .ToArray()
            })
            .ToArray();

        foreach (var e in employees)
        {
            sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
            foreach (var p in e.Projects)
            {
                sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 08 Adresses By Town
    public static string GetAddressesByTown(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var adresses = context.Addresses
            .Select(a => new 
            {
                a.AddressText,
                TownName = a.Town.Name,
                EmployeesCount = a.Employees.Count
            })
            .OrderByDescending(a => a.EmployeesCount)
            .ThenBy(a => a.TownName)
            .ThenBy(a => a.AddressText)
            .Take(10)
            .ToArray();

        foreach (var a in adresses)
        {
            sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 09 Employee 147
    public static string GetEmployee147(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var employee = context.Employees
            .Where(e => e.EmployeeId == 147)
            .Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects
                .Select(p => new
                {
                    p.Project.Name
                })
                .ToArray()
            })
            .ToArray();

        sb.AppendLine($"{employee[0].FirstName} {employee[0].LastName} - {employee[0].JobTitle}");
        foreach (var p in employee[0].Projects.OrderBy(p => p.Name))
        {
            sb.AppendLine($"{p.Name}");
        }

        return sb.ToString().TrimEnd();
    }

    //Problem 10 Departments with More Than 5 Employees
    public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
    {
        StringBuilder sb = new StringBuilder();

        var departments = context.Departments
            .Select(d => new
            {
                d.Name,
                d.Manager,
                d.Employees.Count,
                d.Employees
            })
            .Where(d => d.Count > 5)
            .OrderBy(e => e.Count)
            .ThenBy(e => e.Name)
            .ToArray();

        foreach (var d in departments)
        {
            sb.AppendLine($"{d.Name} - {d.Manager.FirstName} {d.Manager.LastName}");
            foreach (var e in d.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
            }
        }

        return sb.ToString().TrimEnd();
    }
}