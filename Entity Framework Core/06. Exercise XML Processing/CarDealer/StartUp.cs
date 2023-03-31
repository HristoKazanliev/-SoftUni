using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.IO;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context= new CarDealerContext();

            //string inputXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context,inputXml));

            //string inputXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            //Console.WriteLine(ImportParts(context, inputXml));

            //string inputXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            //Console.WriteLine(ImportCars(context, inputXml));

            ///string inputXml = File.ReadAllText(@"../../../Datasets/customers.xml");
            //Console.WriteLine(ImportCustomers(context, inputXml));

            //string inputXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            //Console.WriteLine(ImportSales(context, inputXml));

            //string result = GetCarsWithDistance(context);

            //string result = GetCarsFromMakeBmw(context);

            //string result = GetLocalSuppliers(context);

            //string result = GetCarsWithTheirListOfParts(context);

            //string result = GetTotalSalesByCustomer(context);

            string result = GetSalesWithAppliedDiscount(context);
            
            Console.WriteLine(result);
        }

        //09
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportSupplierDto[] supplierDtos = xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (var supplierDto in supplierDtos)
            {
                if (string.IsNullOrEmpty(supplierDto.Name))
                {
                    continue;
                }

                Supplier supplier = mapper.Map<Supplier>(supplierDto);

                validSuppliers.Add(supplier);
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count}";
        }

        //10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] partDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var partDto in partDtos)
            {
                if (string.IsNullOrEmpty(partDto.Name))
                {
                    continue;
                }

                if (!partDto.SupplierId.HasValue || !context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    continue;
                }

                Part part= mapper.Map<Part>(partDto);
                validParts.Add(part);
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count}";
        }

        //11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carDtos = xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");
            ICollection<Car> validCars = new HashSet<Car>();

            foreach (var carDto in carDtos)
            {
                if (string.IsNullOrEmpty(carDto.Make) || string.IsNullOrEmpty(carDto.Model))
                {
                    continue;
                }

                Car car = mapper.Map<Car>(carDto);

                foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                {
                    if (!context.Parts.Any(p => p.Id == partDto.PartId))
                    {
                        continue;
                    }

                    PartCar partCar = new PartCar()
                    {
                        PartId = partDto.PartId
                    };

                    car.PartsCars.Add(partCar);
                }

                validCars.Add(car);
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count}";
        }

        //12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            IMapper mapper = InitializeAutoMapper();

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();

            foreach (var customerDto in customerDtos)
            {
                if (string.IsNullOrEmpty(customerDto.BirthDate) || string.IsNullOrEmpty(customerDto.Name))
                {
                    continue;
                }

                Customer customer = mapper.Map<Customer>(customerDto);
                validCustomers.Add(customer);
            }

            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count}";
        }

        //13
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();
            IMapper mapper = InitializeAutoMapper();

            ImportSaleDto[] saleDtos = xmlHelper.Deserialize<ImportSaleDto[]>(inputXml, "Sales");

            ICollection<int> dbCarIds = context.Cars.Select(c => c.Id).ToArray();
            ICollection<Sale> validSales = new HashSet<Sale>();

            foreach (var saleDto in saleDtos)
            {
                if (!saleDto.CarId.HasValue || dbCarIds.All(id => id != saleDto.CarId.Value))
                {
                    continue;
                }

                Sale sale = mapper.Map<Sale>(saleDto);
                validSales.Add(sale);
            }

            context.Sales.AddRange(validSales);
            context.SaveChanges();

            return $"Successfully imported {validSales.Count}";
        }

        //14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarDto[] carDtos = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ProjectTo<ExportCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize<ExportCarDto[]>(carDtos, "cars");
        }

        //15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportBmwCarDto[] carDtos = context.Cars
                .Where(c => c.Make.ToUpper() == "BMW")
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TraveledDistance)
                .ProjectTo<ExportBmwCarDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(carDtos, "cars");
        }

        //16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportLocalSupplierDto[] supplierDtos = context.Suppliers
                .Where(s => !s.IsImporter)
                .ProjectTo<ExportLocalSupplierDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(supplierDtos, "suppliers");
        }

        //17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            IMapper mapper = InitializeAutoMapper();
            XmlHelper xmlHelper = new XmlHelper();

            ExportCarWithPartsDto[] carWithPartsDtos = context.Cars
                .OrderByDescending(c => c.TraveledDistance)
                .ThenBy(c => c.Model)
                .Take(5)
                .ProjectTo<ExportCarWithPartsDto>(mapper.ConfigurationProvider)
                .ToArray();

            return xmlHelper.Serialize(carWithPartsDtos, "cars");
        }

        //18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            var tempDto = context.Customers
                .Where(c => c.Sales.Any())
                .Select(c => new 
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SalesInfo = c.Sales.Select(s => new 
                                { 
                                  Prices = c.IsYoungDriver 
                                  ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                                  : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                                }).ToArray()
                })
                .ToArray();

            ExportCustomerDto[] customerDtos = tempDto
                .OrderByDescending(x => x.SalesInfo.Sum(s => s.Prices))
                .Select(c => new ExportCustomerDto()
                { 
                    FullName = c.FullName,
                    BoughtCars = c.BoughtCars,
                    SpentMoney = c.SalesInfo.Sum(s => s.Prices).ToString("f2")
                })
                .ToArray();

            return xmlHelper.Serialize<ExportCustomerDto[]>(customerDtos, "customers");
        }

        //19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ExportSaleDto[] saleDtos = context.Sales
                .Select(s => new ExportSaleDto()
                {
                    Car = new ExportCarDetailsDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance,
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = Math.Round((double)(s.Car.PartsCars.Sum(p => p.Part.Price) 
                                         * (1 - (s.Discount / 100))), 4)
                })
                .ToArray();

            return xmlHelper.Serialize<ExportSaleDto[]>(saleDtos, "sales");
        }

        private static IMapper InitializeAutoMapper()
            => new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));
    }
}