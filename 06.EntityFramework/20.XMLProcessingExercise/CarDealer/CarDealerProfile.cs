namespace CarDealer;

using AutoMapper;

using CarDealer.DTOs.Import;
using CarDealer.Models;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        this.CreateMap<ImportSupplierDto, Supplier>();
    }
}
