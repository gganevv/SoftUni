namespace MiniORM.App;

using MiniORM.App.Data;
using MiniORM.App.Data.Entities;

public class StartUp
{
    static void Main(string[] args)
    {
        //SoftUniDbContext dbContext = new SoftUniDbContext(Config.ConnectionString);

        //Employee newEmployee = new Employee()
        //{
        //    FirstName = "Gosho",
        //    LastName = "Inserted",
        //    DepartmentId = dbContext.Departments.First().Id,
        //    IsEmployed = true
        //};
        //dbContext.Employees.Add(newEmployee);

        //Employee newEmployee = dbContext
        //    .Employees.First(e => e.FirstName == "Gosho");
        //dbContext.Employees.Remove(newEmployee);
        //
        //dbContext.SaveChanges();
    }
}