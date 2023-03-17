namespace CarDealer;

using AutoMapper;
using CarDealer.DTOs.Import;
using CarDealer.Models;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //Supplier
        this.CreateMap<ImportSupplierDto, Supplier>()
            .ForMember(d => d.IsImporter, opt => opt.MapFrom(s => s.IsImporter))
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));

    }
}
