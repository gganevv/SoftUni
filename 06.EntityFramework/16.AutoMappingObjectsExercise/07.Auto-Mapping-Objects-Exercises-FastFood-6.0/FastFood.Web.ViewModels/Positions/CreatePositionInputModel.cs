﻿namespace FastFood.Web.ViewModels.Positions;

using System.ComponentModel.DataAnnotations;

using FastFood.Common.EntityConfiguration;

public class CreatePositionInputModel
{
    [MinLength(ViewModelsValidation.PositionNameMinLength)]
    [MaxLength(ViewModelsValidation.PositionNameMaxLength)]
    public string PositionName { get; set; } = null!;
}