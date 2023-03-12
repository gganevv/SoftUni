﻿namespace FastFood.Web.Controllers;

using System;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Categories;

public class CategoriesController : Controller
{
    private readonly FastFoodContext context;
    private readonly IMapper mapper;

    public CategoriesController(FastFoodContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateCategoryInputModel model)
    {
        throw new NotImplementedException();
    }

    public IActionResult All()
    {
        throw new NotImplementedException();
    }
}