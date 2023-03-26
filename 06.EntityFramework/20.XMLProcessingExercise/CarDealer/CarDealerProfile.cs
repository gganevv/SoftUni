namespace CarDealer;

using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        //Supplier
        this.CreateMap<ImportSupplierDto, Supplier>();
        this.CreateMap<Supplier, ExportLocalSupplierDto>()
            .ForMember(d => d.PartsCount, opt => opt.MapFrom(s => s.Parts.Count()));

        //Part
        this.CreateMap<ImportPartDto, Part>();
        CreateMap<PartCar, DTOs.Export.PartDto>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Part.Name))
            .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Part.Price));

        //Car
        this.CreateMap<ImportCarDto, Car>();
        this.CreateMap<Car, ExportCarWithDistanceDto>();
        this.CreateMap<Car, ExportCarsFromMakeBmwDto>();
        this.CreateMap<Car, ExportCarWithPartDto>()
            .ForMember(d => d.Parts, opt => opt.MapFrom(s => s.PartsCars.OrderByDescending(p => p.Part.Price)));

        //Customer
        this.CreateMap<ImportCustomerDto, Customer>();

        //Sale
        this.CreateMap<ImportSaleDto, Sale>();
    }
}
