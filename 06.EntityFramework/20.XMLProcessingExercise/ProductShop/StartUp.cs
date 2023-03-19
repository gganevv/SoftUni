using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        //01. Import Users
        //string inputXml = File.ReadAllText("../../../Datasets/users.xml");
        //Console.WriteLine(ImportUsers(context, inputXml));

        //02. Import Products
        string inputXml = File.ReadAllText("../../../Datasets/products.xml");
        Console.WriteLine(ImportProducts(context, inputXml));
    }

    //01. Import Users
    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var userDtos = xmlHelper.Deserialize<ImportUserDto[]>(inputXml, "Users");
        var users = new HashSet<User>();
        foreach (var userDto in userDtos)
        {
            User user = mapper.Map<User>(userDto);
            users.Add(user);
        }

        context.Users.AddRange(users);
        context.SaveChanges();
        
        return $"Successfully imported {users.Count}";
    }

    //2. Import Products
    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var productDtos = xmlHelper.Deserialize<ImportProductDto[]>(inputXml, "Products");
        var products = new HashSet<Product>();

        foreach (var productDto in productDtos)
        {
            Product product = mapper.Map<Product>(productDto);
            products.Add(product);
        }

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));
}