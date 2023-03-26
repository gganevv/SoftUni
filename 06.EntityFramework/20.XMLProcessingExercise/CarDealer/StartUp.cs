namespace CarDealer;

using AutoMapper;

using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;

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
        //Console.WriteLine(GetCarsWithDistance(context));

        //15. Export Cars from Make BWM
        //Console.WriteLine(GetCarsFromMakeBmw(context));

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

    //15. Export Cars from Make BMW
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();
        IMapper mapper = CreateMapper();

        var cars = context.Cars
            .Where(c => c.Make == "BMW")
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance);

        var carsDtos = mapper.ProjectTo<ExportCarsFromMakeBmwDto>(cars).ToList();

        return xmlHelper.Serialize(carsDtos, "cars");
    }

    //16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var suppliers = context.Suppliers
            .Where(s => s.IsImporter == false);

        var supplierDtos = mapper.ProjectTo<ExportLocalSupplierDto>(suppliers).ToList();

        return xmlHelper.Serialize(supplierDtos, "suppliers");
    }

    //17. Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var cars = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5);

        var carsDtos = mapper.ProjectTo<ExportCarWithPartDto>(cars).ToList();

        return xmlHelper.Serialize(carsDtos, "cars");
    }

    //18. Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();

        var customers = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new ExportSalesByCustomerDto
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count(),
                SpentMoney = c.IsYoungDriver ? Math.Round(c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).Sum() * 0.95M, 2) : 
                    c.Sales.SelectMany(s => s.Car.PartsCars.Select(pc => pc.Part.Price)).Sum()
            })
            .OrderByDescending(c => c.SpentMoney)
            .ToList();


        return xmlHelper.Serialize(customers, "customers");
    }

    //19. Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();

        var sales = context.Sales
            .Select(s => new ExportSalesWithDiscountDto
            {
                SaleCar = new SaleCarDto
                {
                    CarMake = s.Car.Make,
                    CarModel = s.Car.Model,
                    CarTravelledDistance = s.Car.TraveledDistance
                },
                SaleDiscount = s.Discount,
                CustomerName = s.Customer.Name,
                Price = s.Car.PartsCars.Select(cp => cp.Part.Price).Sum(),
                PriceWithDiscount = Math.Round(s.Car.PartsCars.Select(cp => cp.Part.Price).Sum() * (1 - s.Discount / 100), 2).ToString("f2")
            }).ToArray();

        return xmlHelper.Serialize(sales, "sales");
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}