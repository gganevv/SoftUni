namespace CarDealer;

using System.Globalization;
using Microsoft.EntityFrameworkCore;

using AutoMapper;
using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json.Serialization;

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
        //Console.WriteLine(GetCarsFromMakeToyota(context));

        //16. Export Local Suppliers
        //Console.WriteLine(GetLocalSuppliers(context));

        //17. Export Cars with Their List of Parts
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        //18. Export Total Sales by Customer
        //Console.WriteLine(GetTotalSalesByCustomer(context));

        //19. Export Sales with Applied Discount
        Console.WriteLine(GetSalesWithAppliedDiscount(context));
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

        context.Sales.AddRange(sales);
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
        var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .Select(c => new
                {
                    c.Id,
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                })
                .ToArray();

        return JsonConvert.SerializeObject(cars, Formatting.Indented);
    }

    //16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var suppliers = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count()
            })
            .ToArray();

        return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
    }

    //17. Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var cars = context.Cars
            .Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TravelledDistance
                },
                parts = c.PartsCars
                .Select(c => new
                {
                    c.Part.Name,
                    Price = $"{c.Part.Price:f2}"
                })
            })
            .ToList();

        return JsonConvert.SerializeObject(cars, Formatting.Indented);
    }

    //18.Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customers = context.Customers
            .Where(c => c.Sales.Count >= 1)
            .Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SpentMoney = c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).Sum()
            })
            .OrderByDescending(c => c.SpentMoney)
            .ThenByDescending(c => c.BoughtCars)
            .ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented, CamelCaseNamingStrategy());
    }

    //19. Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
                .Take(10)
                .Select(s => new
                {
                    car = new
                    {
                        s.Car.Make,
                        s.Car.Model,
                        s.Car.TravelledDistance
                    },
                    customerName = s.Customer.Name,
                    discount = $"{s.Discount:f2}",
                    price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):f2}",
                    priceWithDiscount = $"{s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - s.Discount / 100):f2}"
                })
                .ToArray();

        return JsonConvert.SerializeObject(sales, Formatting.Indented);
    }

    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }

    private static JsonSerializerSettings CamelCaseNamingStrategy()
    {
        return new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
