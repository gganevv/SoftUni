namespace FastFood.Services.Data;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

using FastFood.Data;
using FastFood.Web.ViewModels.Items;
using FastFood.Models;

public class ItemsService : IItemsService
{
    private readonly IMapper mapper;
    private readonly FastFoodContext context;

    public ItemsService(IMapper mapper, FastFoodContext context)
    {
        this.mapper = mapper;
        this.context = context;
    }

    public async Task CreateAsync(CreateItemInputModel model)
    {
        Item item = this.mapper.Map<Item>(model);

        await this.context.Items.AddAsync(item);
        await this.context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ItemsAllViewModels>> GetAllAsync()
        => await this.context.Items
            .ProjectTo<ItemsAllViewModels>(this.mapper.ConfigurationProvider)
        .ToArrayAsync();

    public async Task<IEnumerable<CreateItemViewModel>> GetAllAvaibleCategoriesAsync()
        => await this.context.Categories
        .ProjectTo<CreateItemViewModel>(this.mapper.ConfigurationProvider)
        .ToArrayAsync();
}