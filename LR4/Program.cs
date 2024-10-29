using System;
using System.Globalization;
using System.Reflection;

namespace LR4
{
    public class Product
    {
        private string name;
        public decimal price;
        protected int quantity;
        internal string category;
        public DateTime createdDate;

        public Product(string name, decimal price, int quantity, string category)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.category = category;
            this.createdDate = DateTime.Now;
        }

        protected string GetProductInfo()
        {
            var usCulture = new CultureInfo("en-US");
            return $"Product: {name}\nPrice: {price.ToString("C", usCulture)}\nQuantity: {quantity}\nCategory: {category}\nCreated on: {createdDate}";
        }

        public void UpdateQuantity(int newQuantity)
        {
            quantity = newQuantity;
        }

        private bool IsAvailable()
        {
            return quantity > 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Laptop", 1200.99m, 5, "Electronics");
            
            // Type and TypeInfo
            Type productType = typeof(Product);
            TypeInfo productTypeInfo = productType.GetTypeInfo();

            MethodInfo? getProductInfoMethod = productType.GetMethod("GetProductInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            if (getProductInfoMethod != null)
            {
                var productInfo = getProductInfoMethod.Invoke(product, null);
                Console.WriteLine($"{productInfo}");
            }

            Console.WriteLine($"Class Name: {productType.Name}");
            Console.WriteLine($"Class FullName: {productType.FullName}");
            Console.WriteLine($"Class Base Type: {productTypeInfo.BaseType}");
            Console.WriteLine($"Namespace: {productTypeInfo.Namespace}");

            Console.WriteLine("\nConstructors Information:");
            foreach (var constructor in productTypeInfo.DeclaredConstructors)
            {
                Console.WriteLine(constructor);
            }

            // MemberInfo
            Console.WriteLine("\nMembers of Product class:");
            MemberInfo[] members = productType.GetMembers();
            foreach (var member in members)
            {
                Console.WriteLine($"{member.Name} - {member.MemberType}");
            }

            // FieldInfo
            Console.WriteLine("\nField Information:");
            FieldInfo[] fields = productType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                Console.WriteLine($"Field: {field.Name}, Type: {field.FieldType}, Value: {field.GetValue(product)}");
            }

            // Reflection
            FieldInfo? quantityField = productType.GetField("quantity", BindingFlags.NonPublic | BindingFlags.Instance);
            if (quantityField != null)
            {
                quantityField.SetValue(product, 7);
                Console.WriteLine($"\nQuantity after change: {quantityField.GetValue(product)}\n");
            }

            if (getProductInfoMethod != null)
            {
                var productInfo = getProductInfoMethod.Invoke(product, null);
                Console.WriteLine($"{productInfo}");
            }

            // MethodInfo
            Console.WriteLine("\nMethodInfo:");
            MethodInfo[] methods = productType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var method in methods)
            {
                Console.WriteLine($"Method: {method.Name} - Return: {method.ReturnType}");
            }

            // Reflection
            MethodInfo? methodInfo = productType.GetMethod("UpdateQuantity");
            if (methodInfo != null)
                methodInfo.Invoke(product, new object[] { 10 });
            Console.WriteLine($"\nUpdated quantity.");

            if (getProductInfoMethod != null)
            {
                var productInfo = getProductInfoMethod.Invoke(product, null);
                Console.WriteLine($"\nProduct Information through Reflection: {productInfo}");
            }
        }
    }
}
