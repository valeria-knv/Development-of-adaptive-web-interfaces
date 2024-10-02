using Bogus;
using System.Collections.Generic;

namespace LR2
{
    public static class ProductBogusApi
    {
        public static List<ProductBogus> GenerateFakeProducts(int count)
        {
            var faker = new Faker<ProductBogus>()
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Price, f => decimal.Parse(f.Commerce.Price()));

            return faker.Generate(count);
        }
    }
}
