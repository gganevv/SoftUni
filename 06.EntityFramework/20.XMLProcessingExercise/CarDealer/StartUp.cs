namespace CarDealer;

using AutoMapper;

using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;

public class StartUp
{
    public static void Main()
    {
        CarDealerContext context = new CarDealerContext();

        //09. Import Suppliers
        string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
        Console.WriteLine(ImportSuppliers(context, inputXml));
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

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}