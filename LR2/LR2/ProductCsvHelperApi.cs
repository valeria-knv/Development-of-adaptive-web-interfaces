using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace LR2
{
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
}
