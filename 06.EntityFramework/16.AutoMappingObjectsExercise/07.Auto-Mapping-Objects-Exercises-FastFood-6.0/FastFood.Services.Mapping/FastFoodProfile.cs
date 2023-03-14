namespace FastFood.Services.Mapping;

using AutoMapper;

using Models;
using FastFood.Web.ViewModels.Positions;
using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Items;

public class FastFoodProfile : Profile
{
    public FastFoodProfile()
    {
        //Positions
        this.CreateMap<CreatePositionInputModel, Position>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.PositionName));

        this.CreateMap<Position, PositionsAllViewModel>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));

        //Categories
        this.CreateMap<CreateCategoryInputModel, Category>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.CategoryName));

        this.CreateMap<Category, CategoryAllViewModel>();

        //Items
        this.CreateMap<Category, CreateItemViewModel>()
            .ForMember(d => d.CategoryId, opt => opt.MapFrom(s => s.Id))
            .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Name));

        this.CreateMap<CreateItemInputModel, Item>();

        this.CreateMap<Item, ItemsAllViewModels>()
            .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category));
    }
}