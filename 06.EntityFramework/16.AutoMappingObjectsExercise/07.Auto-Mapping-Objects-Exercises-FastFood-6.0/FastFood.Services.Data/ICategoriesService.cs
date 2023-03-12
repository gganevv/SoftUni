namespace FastFood.Services.Data;

using FastFood.Web.ViewModels.Categories;

public interface ICategoriesService
{
    Task CreateAsync(CreateCategoryInputModel model);

    Task<IEnumerable<CategoryAllViewModel>> GetAllAsync();
}