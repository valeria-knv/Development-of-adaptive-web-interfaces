using Grpc.Core;
using System.Collections.Concurrent;

namespace GrpcWebApiExample.Services
{
    public class ProductServiceImpl : ProductService.ProductServiceBase // Використовуємо правильний базовий клас
    {
        private readonly ConcurrentDictionary<int, ProductResponse> _products = new();

        public ProductServiceImpl()
        {
            _products.TryAdd(1, new ProductResponse { Id = 1, Name = "Product A", Price = 10.5 });
            _products.TryAdd(2, new ProductResponse { Id = 2, Name = "Product B", Price = 20.0 });
        }

        public override Task<ProductResponse> GetProductById(ProductRequest request, ServerCallContext context)
        {
            if (_products.TryGetValue(request.Id, out var product))
            {
                return Task.FromResult(product);
            }
            throw new RpcException(new Status(StatusCode.NotFound, "Product not found"));
        }

        public override async Task GetAllProducts(Empty request, IServerStreamWriter<ProductResponse> responseStream, ServerCallContext context)
        {
            foreach (var product in _products.Values)
            {
                await responseStream.WriteAsync(product);
            }
        }

        public override async Task<AddProductResponse> AddProduct(IAsyncStreamReader<ProductRequest> requestStream, ServerCallContext context)
        {
            int totalAdded = 0;

            await foreach (var request in requestStream.ReadAllAsync())
            {
                var product = new ProductResponse
                {
                    Id = request.Id,
                    Name = request.Name,
                    Price = request.Price
                };

                if (_products.TryAdd(product.Id, product))
                {
                    totalAdded++;
                }
            }

            return new AddProductResponse { TotalAdded = totalAdded };
        }

        public override async Task ChatWithServer(IAsyncStreamReader<ProductRequest> requestStream, IServerStreamWriter<ProductResponse> responseStream, ServerCallContext context)
        {
            await foreach (var request in requestStream.ReadAllAsync())
            {
                var response = new ProductResponse
                {
                    Id = request.Id,
                    Name = $"Echo: {request.Name}",
                    Price = request.Price + 1.0
                };

                await responseStream.WriteAsync(response);
            }
        }
    }
}
