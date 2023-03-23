namespace CarDealer;

using AutoMapper;

using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using Microsoft.EntityFrameworkCore;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        //09. Import Suppliers
        //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
        //Console.WriteLine(ImportSuppliers(context, inputXml));

        //10. Import Parts
        //string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
        //Console.WriteLine(ImportParts(context, inputXml));

        //11. Import Cars
        string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
        Console.WriteLine(ImportCars(context, inputXml));
    }

    //09. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        XmlHelper xmlHelper = new XmlHelper();
        IMapper mapper = CreateMapper();

        ImportSupplierDto[] importSupplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");
        HashSet<Supplier> suppliers = new HashSet<Supplier>();

        foreach (var supplierDto in importSupplierDtos)
        {
            Supplier supplier = mapper.Map<Supplier>(supplierDto);
            suppliers.Add(supplier);
        }

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}";
    }

    //10. Import Parts
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        XmlHelper xmlHelper = new XmlHelper();
        IMapper mapper = CreateMapper();

        ImportPartDto[] importPartDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");
        HashSet<Part> parts = new HashSet<Part>();

        List<int> supplierIds = context.Suppliers
            .Select(x => x.Id).ToList();

        foreach (var partDto in importPartDtos)
        {
            Part part = mapper.Map<Part>(partDto);
            if (supplierIds.Contains(part.SupplierId))
            {
                parts.Add(part);
            }
        }

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}";
    }

    //11. Import Cars
    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportCarDto[] importCarDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

        HashSet<Car> cars = new HashSet<Car>();
        foreach (var carDto in importCarDtos)
        {
            Car car = mapper.Map<Car>(carDto);

            foreach (var part in carDto.Parts.DistinctBy(p => p.Id))
            {
                if (!context.Parts.Any(p => p.Id == part.Id))
                {
                    continue;
                }

                PartCar partCar = new PartCar()
                {
                    PartId = part.Id
                };

                car.PartsCars.Add(partCar);

            }
            cars.Add(car);
        }

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}";
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}