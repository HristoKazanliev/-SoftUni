using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Diagnostics.Metrics;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //string inputJson = File.ReadAllText(@"../../../Datasets/users.json");
            //string result = ImportUsers(context, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/products.json");
            //string result = ImportProducts(context, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories.json");
            //string result = ImportCategories(context, inputJson);

            //string inputJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            //string result = ImportCategoryProducts(context, inputJson);

            //string result = GetProductsInRange(context);
            //string result = GetSoldProducts(context);
            //string result = GetCategoriesByProductsCount(context);
            string result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        //01
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportUserDto[] userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (var userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }

        //02
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            Product[] products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //03
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryDto[] categoryDtos = JsonConvert.DeserializeObject<ImportCategoryDto[]>(inputJson);

            ICollection<Category> validCategories = new HashSet<Category>();

            foreach (var categoryDto in categoryDtos)
            {
                if (String.IsNullOrEmpty(categoryDto.Name))
                {
                    continue;
                }

                Category category= mapper.Map<Category>(categoryDto);
                validCategories.Add(category);
            }

            context.Categories.AddRange(validCategories);
            context.SaveChanges();

            return $"Successfully imported {validCategories.Count}";
        }

        //04
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            IMapper mapper = CreateMapper();

            ImportCategoryProductDto[] categoryProductDtos = JsonConvert.DeserializeObject<ImportCategoryProductDto[]>(inputJson);

            ICollection<CategoryProduct> validCategoryProducts = new HashSet<CategoryProduct>();

            foreach (var item in categoryProductDtos)
            {
                //if (!context.Categories.Any(c => c.Id == item.CategoryId) || !context.Products.Any(p => p.Id == item.ProductId))
                //{
                //    continue;
                //}

                CategoryProduct categoryProduct = mapper.Map<CategoryProduct>(item);
                validCategoryProducts.Add(categoryProduct);
            }

            context.CategoriesProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }

        //05
        public static string GetProductsInRange(ProductShopContext context)
        {
            IMapper mapper = CreateMapper();

            ExportProductInRangeDto[] productDtos = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .AsNoTracking()
                .ProjectTo<ExportProductInRangeDto>(mapper.ConfigurationProvider)
                .ToArray();

            return JsonConvert.SerializeObject(productDtos, Formatting.Indented);
        }

        //06
        public static string GetSoldProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

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
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });
        }

        //07
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var categories = context.Categories
                .OrderByDescending(c => c.CategoriesProducts.Count)
                .Select(c => new 
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = c.CategoriesProducts.Average(p => p.Product.Price).ToString("f2"),
                    TotalRevenue = c.CategoriesProducts.Sum(p => p.Product.Price).ToString("f2")
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(categories,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });
        }

        //08
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var usersWithProducts = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new 
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new 
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold.Where(p => p.Buyer != null)
                            .Select(p => new 
                            {
                                p.Name,
                                p.Price,
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .AsNoTracking()
                .ToArray();

            var userWrapperDto = new
            {
                UsersCount = usersWithProducts.Length,
                Users = usersWithProducts
            };

            return JsonConvert.SerializeObject(userWrapperDto,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver,
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

        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }
    }
}