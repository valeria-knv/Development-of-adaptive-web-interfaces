using System;
using System.Collections.Generic;
using System.Globalization;
using NodaTime;



namespace LR2
{
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

            Console.ReadKey();
        }
    }

}