namespace LR2
{
    public static class ProductFluentValidationApi
    {
        public static bool ValidateProduct(ProductFluentValidation product)
        {
            var validator = new ProductValidator();
            var result = validator.Validate(product);
            return result.IsValid;
        }
    }
}
