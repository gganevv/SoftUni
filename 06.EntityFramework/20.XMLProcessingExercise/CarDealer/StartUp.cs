namespace CarDealer;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
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
        //string inputXml = File.ReadAllText("../../../Datasets/cars.xml");
        //Console.WriteLine(ImportCars(context, inputXml));

        //12. Import Customers
        //string inputXml = File.ReadAllText("../../../Datasets/customers.xml");
        //Console.WriteLine(ImportCustomers(context, inputXml));

        //13. Import Sales
        //string inputXml = File.ReadAllText("../../../Datasets/sales.xml");
        //Console.WriteLine(ImportSales(context, inputXml));

        //14. Export Cars with Distance
        Console.WriteLine(GetCarsWithDistance(context));
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

    //12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportCustomerDto[] importCustomerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");
        HashSet<Customer> customers = new HashSet<Customer>();

        foreach (var customerDto in importCustomerDtos)
        {
            Customer customer = mapper.Map<Customer>(customerDto);
            customers.Add(customer);
        }

        context.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}"; ;
    }

    //13. Import Sales
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        ImportSaleDto[] importSaleDtos = xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");
        HashSet<Sale> sales = new HashSet<Sale>();

        var carIds = context.Cars
            .Select(c => c.Id)
            .ToHashSet();

        foreach (var saleDto in importSaleDtos)
        {
            Sale sale = mapper.Map<Sale>(saleDto);
            if (carIds.Contains(sale.CarId))
            {
                sales.Add(sale);
            }
        }

        context.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}";
    }

    //14. Export Cars with Distance
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();
        IMapper mapper = CreateMapper();

        var cars = context.Cars
            .Where(c => c.TraveledDistance > 2000000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10);

        var carsDtos = mapper.ProjectTo<ExportCarWithDistanceDto>(cars).ToList();

        return xmlHelper.Serialize(carsDtos, "cars");
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}