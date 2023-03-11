﻿namespace FastFood.Core.Controllers;

using System;
using System.Linq;
using AutoMapper;
using Data;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Orders;

public class OrdersController : Controller
{
    private readonly FastFoodContext context;
    private readonly IMapper mapper;

    public OrdersController(FastFoodContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    public IActionResult Create()
    {
        //var viewOrder = new CreateOrderViewModel
        //{
        //    Items = this.context.Items.Select(x => x.Id).ToList(),
        //    Employees = this.context.Employees.Select(x => x.Id).ToList(),
        //};

        return View();
    }

    [HttpPost]
    public IActionResult Create(CreateOrderInputModel model)
    {
        return RedirectToAction("All", "Orders");
    }

    public IActionResult All()
    {
        throw new NotImplementedException();
    }
}