using FastFood.Web.ViewModels.Employees;

namespace FastFood.Services.Data;

public interface IEmployeesService
{
    Task CreateAsync(RegisterEmployeeInputModel model);

    Task<IEnumerable<EmployeesAllViewModel>> GetAllAsync();

    Task<IEnumerable<RegisterEmployeeViewModel>> GetAllAvaiblePositionsAsync();
}