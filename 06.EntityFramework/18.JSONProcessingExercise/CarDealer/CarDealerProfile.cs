﻿namespace CarDealer;

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

        //Part
        this.CreateMap<ImportPartDto, Part>()
            .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
            .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price))
            .ForMember(d => d.Quantity, opt => opt.MapFrom(s => s.Quantity))
            .ForMember(d => d.SupplierId, opt => opt.MapFrom(s => s.SupplierId));

        //Car
        this.CreateMap<ImportCarDto, Car>()
            .ForMember(d => d.Make, opt => opt.MapFrom(s => s.Make))
            .ForMember(d => d.Model, opt => opt.MapFrom(s => s.Model))
            .ForMember(d => d.TravelledDistance, opt => opt.MapFrom(s => s.TravelledDistance))
            .ForMember(d => d.PartsCars, opt => opt.Ignore());
    }
}
