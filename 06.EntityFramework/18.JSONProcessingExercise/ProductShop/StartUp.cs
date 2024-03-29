﻿namespace ProductShop;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

public class StartUp
{
    public static void Main()
    {
        ProductShopContext context = new ProductShopContext();

        //01. Import Users
        //string imputJson = File.ReadAllText(@"../../../Datasets/users.json");
        //Console.WriteLine(ImportUsers(context, imputJson));

        //02. Import Products
        //string imputJson = File.ReadAllText(@"../../../Datasets/products.json");
        //Console.WriteLine(ImportProducts(context, imputJson));

        //03. Import Categories
        //string inputJson = File.ReadAllText("../../../Datasets/categories.json");
        //Console.WriteLine(ImportCategories(context, inputJson));

        //04. Import Categories and Products
        //string inputJson = File.ReadAllText("../../../Datasets/categories-products.json");
        //Console.WriteLine(ImportCategoryProducts(context, inputJson));

        //05. Export Products in Range
        //Console.WriteLine(GetProductsInRange(context));

        //06. Export Sold Products
        //Console.WriteLine(GetSoldProducts(context));

        //07. Export Categories by Products Count
        //Console.WriteLine(GetCategoriesByProductsCount(context));

        //08. Export Users and Products
        Console.WriteLine(GetUsersWithProducts(context));
    }

    //01. Import Users
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

        ICollection<User> users = new HashSet<User>();
        foreach (ImportUserDto userDto in userDtos)
        {
            User user = mapper.Map<User>(userDto);
            users.Add(user);
        }

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }

    //02. Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        HashSet<Product> products = new HashSet<Product>();

        ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);
        foreach (ImportProductDto dto in productDtos)
        {
            Product product = mapper.Map<Product>(dto);

            products.Add(product);
        }

        context.Products.AddRange(products);

        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    //03. Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();
        HashSet<Category> categories = new HashSet<Category>();

        
        ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);
        foreach (var categoryDto in categoryDtos)
        {
            Category category = mapper.Map<Category>(categoryDto);
            if (string.IsNullOrEmpty(category.Name))
            {
                continue;
            }
            categories.Add(category);
        }

        context.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    //04. Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = CreateMapper();

        HashSet<CategoryProduct> categoryProducts = new HashSet<CategoryProduct>();

        ImportCategoryProductDto[] categoryProductsDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

        foreach (var categoryProductDto in categoryProductsDtos)
        {
            CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(categoryProductDto);
            categoryProducts.Add(categoryProduct);
        }

        context.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count}";
    }

    //05. Export products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        IMapper mapper = CreateMapper();

        ExportProductInRangeDto[] prodcts = context
            .Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
            .ToArray();

        return JsonConvert.SerializeObject(prodcts, Formatting.Indented);
    }

    //06. Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        var usersWithSoldProducts = context.Users
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                SoldProducts = u.ProductsSold
                .Where(p => p.Buyer != null)
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    BuyerFirstName = p.Buyer.FirstName,
                    BuyerLastName = p.Buyer.LastName
                })
                .ToArray()
            })
            .AsNoTracking()
            .ToArray();

        return JsonConvert.SerializeObject(usersWithSoldProducts,
            Formatting.Indented,
            CamelCaseNamingStrategy());
    }

    //07. Export Categories by Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .OrderByDescending(c => c.CategoriesProducts.Count())
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count(),
                AveragePrice = c.CategoriesProducts.Select(p => p.Product.Price).Average().ToString("f2"),
                TotalRevenue = c.CategoriesProducts.Select(p => p.Product.Price).Sum().ToString("f2")
            })
            .ToArray();
        return JsonConvert.SerializeObject(categories, Formatting.Indented, CamelCaseNamingStrategy());
    }

    //08. Export Users and Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = new
                {
                    Count = u.ProductsSold.Count(p => p.Buyer != null),
                    Products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price
                        })
                }
            })
            .OrderByDescending(u => u.SoldProducts.Count)
            .ToArray();

        var usersWrapper = new
        {
            UsersCount = users.Count(),
            Users = users
        };

        return JsonConvert.SerializeObject(usersWrapper,
               Formatting.Indented,
               new JsonSerializerSettings()
               {
                   ContractResolver = new CamelCasePropertyNamesContractResolver(),
                   NullValueHandling = NullValueHandling.Ignore
               });
    }

    private static IMapper CreateMapper()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
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