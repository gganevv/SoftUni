namespace FastFood.Services.Data;

using FastFood.Web.ViewModels.Positions;

public interface IPositionsService
{
    Task CreateAsync(CreatePositionInputModel model);

    Task<IEnumerable<PositionsAllViewModel>> GetAllAsync();
}