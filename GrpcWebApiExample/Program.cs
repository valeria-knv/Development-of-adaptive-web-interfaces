using Grpc.Net.Client;
using GrpcWebApiExample.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<ProductServiceImpl>();

app.Run();