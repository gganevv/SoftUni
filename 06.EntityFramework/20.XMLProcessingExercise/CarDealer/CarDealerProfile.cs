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

        //Car
        this.CreateMap<ImportCarDto, Car>();
        this.CreateMap<Car, ExportCarWithDistanceDto>();
        this.CreateMap<Car, ExportCarsFromMakeBmwDto>();

        //Customer
        this.CreateMap<ImportCustomerDto, Customer>();

        //Sale
        this.CreateMap<ImportSaleDto, Sale>();
    }
}
