namespace CarDealer;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.Globalization;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        //09. Import Suppliers
        //string inputJson = File.ReadAllText("../../../Datasets/suppliers.json");
        //Console.WriteLine(ImportSuppliers(context, inputJson));

        //10. Import Parts
        //string inputJson = File.ReadAllText("../../../Datasets/parts.json");
        //Console.WriteLine(ImportParts(context, inputJson));

        //11. Import Cars
        //string inputJson = File.ReadAllText("../../../Datasets/cars.json");
        //Console.WriteLine(ImportCars(context, inputJson));

        //12. Import Customers
        //string inputJson = File.ReadAllText("../../../Datasets/customers.json");
        //Console.WriteLine(ImportCustomers(context, inputJson));

        //13. Import Sales
        //string inputJson = File.ReadAllText("../../../Datasets/sales.json");
        //Console.WriteLine(ImportSales(context, inputJson));

        //14. Export Ordered Customers
        //Console.WriteLine(GetOrderedCustomers(context));

        //15. Export Cars from Make Toyota
        Console.WriteLine(GetCarsFromMakeToyota(context));
    }

    //09. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportSupplierDto[] importSupplierDtos = JsonConvert.DeserializeObject<ImportSupplierDto[]>(inputJson);

        HashSet<Supplier> suppliers = new HashSet<Supplier>();
        foreach (var importSupplierDto in importSupplierDtos)
        {
            Supplier supplier = mapper.Map<Supplier>(importSupplierDto);
            suppliers.Add(supplier);
        }

        context.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }

    //10. Import Parts
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        HashSet<Part> parts = new HashSet<Part>();
        ImportPartDto[] importPartDtos = JsonConvert.DeserializeObject<ImportPartDto[]>(inputJson);

        int[] supplierIds = context.Suppliers.Select(s => s.Id).ToArray();

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

        return $"Successfully imported {parts.Count}.";
    }

    //11. Import Cars
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        HashSet<Car> cars = new HashSet<Car>();
        HashSet<PartCar> partCars = new HashSet<PartCar>();

        ImportCarDto[] importCarDtos = JsonConvert.DeserializeObject<ImportCarDto[]>(inputJson);
        foreach (var carDto in importCarDtos)
        {
            Car car = mapper.Map<Car>(carDto);
            cars.Add(car);

            foreach (var part in carDto.PartsCars)
            {
                var partCar = new PartCar()
                {
                    Car = car,
                    PartId = part
                };
                partCars.Add(partCar);
            }
        }

        context.Cars.AddRange(cars);
        context.PartsCars.AddRange(partCars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    //12. Import Customers 
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        HashSet<Customer> customers = new HashSet<Customer>();

        ImportCustomerDto[] importCustomerDtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
        foreach (var customerDto in importCustomerDtos)
        {
            Customer customer = mapper.Map<Customer>(customerDto);
            customers.Add(customer);
        }

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}.";
    }

    //13. Import Sales
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        ImportSaleDto[] importSaleDtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
        HashSet<Sale> sales = new HashSet<Sale>();

        foreach (var saleDto in importSaleDtos)
        {
            Sale sale = mapper.Map<Sale>(saleDto);
            sales.Add(sale);
        }

        context.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}.";
    }

    //14. Export Ordered Customers
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var customers = context.Customers
            .OrderBy(x => x.BirthDate)
            .ThenBy(x => x.IsYoungDriver)
            .Select(c => new
            {
                c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                c.IsYoungDriver
            })
            .AsNoTracking()
            .ToList();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }

    //15. Export Cars from Make Toyota
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var carsFromMakeToyota = context.Cars
            .Where(c => c.Make == "Toyota")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TravelledDistance)
            .Select(c => new
            {
                Id = c.Id,
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TravelledDistance
            })
            .ToArray();

        return JsonConvert.SerializeObject(carsFromMakeToyota, Formatting.Indented);
    }

    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}
