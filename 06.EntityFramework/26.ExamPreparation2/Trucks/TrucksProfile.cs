namespace Trucks;

using AutoMapper;
using Trucks.Data.Models;
using Trucks.DataProcessor.ImportDto;

public class TrucksProfile : Profile
{
    public TrucksProfile()
    {
        //Despatcher
        this.CreateMap<ImportDespatcherDto, Despatcher>()
            .ForMember(s => s.Trucks, opt => opt.Ignore());

        //Truck
        this.CreateMap<ImportTruckDto, Truck>();
    }
}
