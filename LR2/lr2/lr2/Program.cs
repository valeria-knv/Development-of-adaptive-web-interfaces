using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using AutoMapper;
using Bogus;
using ClosedXML.Excel;
using CsvHelper;
using FluentValidation;
using NodaTime;



namespace lr2
{
    namespace ProductApiExample
    {
        // Product 1: Bogus
        public class ProductBogus
        {
            public string? Name { get; set; }
            public decimal Price { get; set; }
        }

        public static class ProductBogusApi
        {
            public static List<ProductBogus> GenerateFakeProducts(int count)
            {
                var faker = new Faker<ProductBogus>()
                    .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price())); ;

                return faker.Generate(count);
            }
        }

        // Product 2: FluentValidation
        public class ProductFluentValidation
        {
            public string? Name { get; set; }
            public decimal Price { get; set; }
        }

        public class ProductValidator : AbstractValidator<ProductFluentValidation>
        {
            public ProductValidator()
            {
                RuleFor(p => p.Name).NotEmpty().WithMessage("Product name cannot be empty");
                RuleFor(p => p.Price).GreaterThan(0).WithMessage("Price must be greater than zero");
            }
        }

        public static class ProductFluentValidationApi
        {
            public static bool ValidateProduct(ProductFluentValidation product)
            {
                var validator = new ProductValidator();
                var result = validator.Validate(product);
                return result.IsValid;
            }
        }

        // Product 3: AutoMapper
        public class ProductDto
        {
            public string? Name { get; set; }
            public decimal Price { get; set; }
        }

        public class ProductDomain
        {
            public string? Name { get; set; }
            public decimal Price { get; set; }
        }

        public static class ProductAutoMapperApi
        {
            private static IMapper mapper;

            static ProductAutoMapperApi()
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDto, ProductDomain>());
                mapper = config.CreateMapper();
            }

            public static ProductDomain MapProduct(ProductDto dto)
            {
                return mapper.Map<ProductDomain>(dto);
            }
        }

        // Product 4: CsvHelper
        public class ProductCsv
        {
            public string? Name { get; set; }
            public decimal Price { get; set; }
        }

        public static class ProductCsvHelperApi
        {
            public static void WriteProductsToCsv(List<ProductCsv> products, string filePath)
            {
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(products);
                }
            }

            public static List<ProductCsv> ReadProductsFromCsv(string filePath)
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    return new List<ProductCsv>(csv.GetRecords<ProductCsv>());
                }
            }
        }

        // Product 5: ClosedXML and NodaTime
        public class ProductWithDate
        {
            public string? Name { get; set; }
            public decimal Price { get; set; }
            public LocalDateTime CreatedDate { get; set; }
        }

        public static class ProductClosedXmlNodaTimeApi
        {
            public static void ExportToExcel(List<ProductWithDate> products, string filePath)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("Products");
                    worksheet.Cell(1, 1).Value = "Name";
                    worksheet.Cell(1, 2).Value = "Price";
                    worksheet.Cell(1, 3).Value = "CreatedDate";

                    for (int i = 0; i < products.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = products[i].Name;
                        worksheet.Cell(i + 2, 2).Value = products[i].Price;
                        worksheet.Cell(i + 2, 3).Value = products[i].CreatedDate.ToString();
                    }

                    workbook.SaveAs(filePath);
                }
            }

            public static List<ProductWithDate> ImportFromExcel(string filePath)
            {
                var products = new List<ProductWithDate>();
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheets.Worksheet(1);
                    var rows = worksheet.RowsUsed();
                    foreach (var row in rows)
                    {
                        if (row.RowNumber() == 1) continue;

                        var name = row.Cell(1).GetString();
                        var price = row.Cell(2).GetValue<decimal>();

                        LocalDateTime createdDate;

                        try
                        {
                            var dateString = row.Cell(3).GetString();

                            if (DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm:ss",
                                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateTimeValue))
                            {
                                createdDate = LocalDateTime.FromDateTime(dateTimeValue);
                            }
                            else
                            {
                                throw new FormatException("Неправильний формат дати.");
                            }
                        }
                        catch (Exception ex) when (ex is FormatException || ex is InvalidCastException)
                        {
                            createdDate = LocalDateTime.FromDateTime(DateTime.MinValue);
                            Console.WriteLine("Неможливо перетворити значення в дату: " + ex.Message);
                        }

                        products.Add(new ProductWithDate { Name = name, Price = price, CreatedDate = createdDate });
                    }
                }
                return products;
            }
        }

        // Example usage of the APIs
        class Program
        {
            static void Main(string[] args)
            {
                var culture = new CultureInfo("en-US");

                // Bogus
                var fakeProducts = ProductBogusApi.GenerateFakeProducts(5);
                Console.WriteLine("Fake Products:");
                fakeProducts.ForEach(p => Console.WriteLine($"{p.Name} - {p.Price.ToString("C", culture)}"));

                // FluentValidation
                var productToValidate = new ProductFluentValidation { Name = "Product1", Price = 100 };
                var isValid = ProductFluentValidationApi.ValidateProduct(productToValidate);
                Console.WriteLine($"Is product valid: {isValid}");

                // AutoMapper
                var productDto = new ProductDto { Name = "ProductDto", Price = 150 };
                var mappedProduct = ProductAutoMapperApi.MapProduct(productDto);
                Console.WriteLine($"Mapped Product: {mappedProduct.Name} - {mappedProduct.Price.ToString("C", culture)}");

                // CsvHelper
                var csvProducts = new List<ProductCsv>
            {
                new ProductCsv { Name = "CsvProduct1", Price = 200 },
                new ProductCsv { Name = "CsvProduct2", Price = 300 }
            };
                string csvPath = "products.csv";
                ProductCsvHelperApi.WriteProductsToCsv(csvProducts, csvPath);
                var readProducts = ProductCsvHelperApi.ReadProductsFromCsv(csvPath);
                Console.WriteLine("Read Products from CSV:");
                readProducts.ForEach(p => Console.WriteLine($"{p.Name} - {p.Price.ToString("C", culture)}"));

                // ClosedXML and NodaTime
                var productsWithDate = new List<ProductWithDate>
            {
                new ProductWithDate { Name = "ExcelProduct1", Price = 400, CreatedDate = LocalDateTime.FromDateTime(DateTime.Now) },
                new ProductWithDate { Name = "ExcelProduct2", Price = 500, CreatedDate = LocalDateTime.FromDateTime(DateTime.Now) }
            };
                string excelPath = "products.xlsx";
                ProductClosedXmlNodaTimeApi.ExportToExcel(productsWithDate, excelPath);
                var importedProducts = ProductClosedXmlNodaTimeApi.ImportFromExcel(excelPath);
                Console.WriteLine("Imported Products from Excel:");
                importedProducts.ForEach(p => Console.WriteLine($"{p.Name} - {p.Price.ToString("C", culture)} - {p.CreatedDate}"));
            }
        }
    }


}