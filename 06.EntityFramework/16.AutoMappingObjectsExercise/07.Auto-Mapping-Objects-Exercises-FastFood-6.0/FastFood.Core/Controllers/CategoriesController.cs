namespace FastFood.Web.Controllers;

using System;
using FastFood.Services.Data;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Categories;

public class CategoriesController : Controller
{
    private readonly ICategoriesService categoriesService;

    public CategoriesController(ICategoriesService categoriesService)
    {
        this.categoriesService = categoriesService;
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryInputModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return this.RedirectToAction("Error", "Home");
        }

        await this.categoriesService.CreateAsync(model);

        return this.RedirectToAction("All");
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<CategoryAllViewModel> categories = 
            await this.categoriesService.GetAllAsync();

        return this.View(categories.ToList());
    }
}