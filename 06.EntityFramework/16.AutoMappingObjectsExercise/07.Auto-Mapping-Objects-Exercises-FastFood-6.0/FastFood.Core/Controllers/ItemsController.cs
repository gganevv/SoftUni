﻿namespace FastFood.Core.Controllers;

using System;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Items;

public class ItemsController : Controller
{
    private readonly FastFoodContext context;
    private readonly IMapper mapper;

    public ItemsController(FastFoodContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public IActionResult Create()
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public IActionResult Create(CreateItemInputModel model)
    {
        throw new NotImplementedException();
    }

    public IActionResult All()
    {
        throw new NotImplementedException();
    }
}