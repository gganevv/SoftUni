namespace ProductShop;

using AutoMapper;

using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using ProductShop.Utilities;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        //01. Import Users
        //string inputXml = File.ReadAllText("../../../Datasets/users.xml");
        //Console.WriteLine(ImportUsers(context, inputXml));

        //02. Import Products
        //string inputXml = File.ReadAllText("../../../Datasets/products.xml");
        //Console.WriteLine(ImportProducts(context, inputXml));

        //03. Import Categories
        //string inputXml = File.ReadAllText("../../../Datasets/categories.xml");
        //Console.WriteLine(ImportCategories(context, inputXml));

        //04. Import Categories and Products
        //string inputXml = File.ReadAllText("../../../Datasets/categories-products.xml");
        //Console.WriteLine(ImportCategoryProducts(context, inputXml));

        //05. Export Products in Range
        //Console.WriteLine(GetProductsInRange(context));

        //06. Export Sold Products
        Console.WriteLine(GetSoldProducts(context));
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

    //03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var categoryDtos = xmlHelper.Deserialize<ImportCategoryDto[]>(inputXml, "Categories");
        var categories = new HashSet<Category>();

        foreach (var categoryDto in categoryDtos)
        {
            Category category = mapper.Map<Category>(categoryDto);
            if (category.Name != null)
            {
                categories.Add(category);
            }
        }

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    //04. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var CategoryProductDtos = xmlHelper.Deserialize<ImportCategoryProductDto[]>(inputXml, "CategoryProducts");
        var categoryProducts = new HashSet<CategoryProduct>();

        foreach (var categoryProductDto in CategoryProductDtos)
        {
            CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
            categoryProducts.Add(categoryProduct);
        }

        context.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count}";
    }

    //05. Export Products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        IMapper mapper = CreateMapper();
        XmlHelper xmlHelper = new XmlHelper();

        var products = context.Products
            .Where(x => x.Price >= 500 && x.Price <= 1000)
            .OrderBy(x => x.Price)
            .Take(10)
            .Select(p => new ExportProductInRangeDto()
            {
                Price = p.Price,
                Name = p.Name,
                BuyerName = p.Buyer.FirstName + " " + p.Buyer.LastName
            })
            .ToArray();

        string result = xmlHelper.Serialize<ExportProductInRangeDto[]>(products, "Products");

        return result;
    }

    //06. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        XmlHelper xmlHelper = new XmlHelper();

        var products = context.Users
            .Where(u => u.ProductsSold.Count > 0)
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Take(5)
            .Select(u => new ExportSoldProductDto
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                ProductDtos = u.ProductsSold.Select( p => new ProductDto
                {
                    ProductName = p.Name,
                    Price = p.Price
                }).ToArray()
            })
            .ToArray();

        return xmlHelper.Serialize(products, "Users");
    }

    private static IMapper CreateMapper()
        => new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));
}