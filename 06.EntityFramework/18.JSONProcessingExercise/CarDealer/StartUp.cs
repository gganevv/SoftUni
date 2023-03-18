namespace CarDealer;

using Microsoft.EntityFrameworkCore;

using AutoMapper;
using Newtonsoft.Json;

using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;

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
        string inputJson = File.ReadAllText("../../../Datasets/customers.json");
        Console.WriteLine(ImportCustomers(context, inputJson));
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

    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }
}
