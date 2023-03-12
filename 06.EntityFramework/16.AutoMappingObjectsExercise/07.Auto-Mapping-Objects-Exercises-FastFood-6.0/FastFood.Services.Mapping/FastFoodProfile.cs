namespace FastFood.Services.Mapping;

using AutoMapper;

using Models;
using FastFood.Web.ViewModels.Positions;
using FastFood.Web.ViewModels.Categories;

public class FastFoodProfile : Profile
{
    public FastFoodProfile()
    {
        //Positions
        this.CreateMap<CreatePositionInputModel, Position>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

        this.CreateMap<Position, PositionsAllViewModel>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

        //Categories
        this.CreateMap<CreateCategoryInputModel, Category>()
            .ForMember(x => x.Name, y => y.MapFrom(s => s.CategoryName));

        this.CreateMap<Category, CategoryAllViewModel>();
    }
}