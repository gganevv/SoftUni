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
        //string inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");
        //Console.WriteLine(ImportSuppliers(context, inputXml));

        //10. Import Parts
        string inputXml = File.ReadAllText("../../../Datasets/parts.xml");
        Console.WriteLine(ImportParts(context, inputXml));
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

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
}