﻿namespace FastFood.Web.ViewModels.Employees;

public class RegisterEmployeeInputModel
{
    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public int PositionId { get; set; }

    public string Address { get; set; } = null!;
}