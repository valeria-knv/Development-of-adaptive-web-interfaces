using ClosedXML.Excel;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace LR2
{
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
                            throw new FormatException("Incorrect date format.");
                        }
                    }
                    catch (Exception ex) when (ex is FormatException || ex is InvalidCastException)
                    {
                        createdDate = LocalDateTime.FromDateTime(DateTime.MinValue);
                        Console.WriteLine("Cannot convert value to date: " + ex.Message);
                    }

                    products.Add(new ProductWithDate { Name = name, Price = price, CreatedDate = createdDate });
                }
            }
            return products;
        }

    }
}
