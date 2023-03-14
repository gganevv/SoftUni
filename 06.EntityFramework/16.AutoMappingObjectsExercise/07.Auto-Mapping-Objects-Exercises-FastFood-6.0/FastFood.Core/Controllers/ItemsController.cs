namespace FastFood.Web.Controllers;

using System;
using FastFood.Services.Data;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Items;

public class ItemsController : Controller
{
    private readonly IItemsService itemsService;

    public ItemsController(IItemsService itemsService)
    {
        this.itemsService = itemsService;
    }

    [HttpGet]
    public async Task<IActionResult> Create()
    {
        IEnumerable<CreateItemViewModel> avaibleCategories =
            await this.itemsService.GetAllAvaibleCategoriesAsync();
        return this.View(avaibleCategories);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateItemInputModel model)
    {
        if (!this.ModelState.IsValid)
        {
            return this.RedirectToAction("Error", "Home");
        }

        await this.itemsService.CreateAsync(model);

        return this.RedirectToAction("All");
    }

    public async Task<IActionResult> All()
    {
        IEnumerable<ItemsAllViewModels> items
            = await this.itemsService.GetAllAsync();

        return this.View(items.ToList());
    }
}