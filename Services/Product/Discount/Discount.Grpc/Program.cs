using Discount.Grpc.Data;
using Discount.Grpc.Data.Interface;
using Discount.Grpc.Repositories;
using Discount.Grpc.Repositories.Interface;
using Discount.Grpc.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IDiscountRipository, DiscountRipository>();
builder.Services.AddScoped<IDiscountContext, DiscountContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGrpcService<DiscountService>();

    endpoints.MapGet("/", async context =>
    {
        await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
    });
});




//services.AddScoped<IDiscountRipository, DiscountRipository>();
//services.AddAutoMapper(typeof(Startup));
//services.AddGrpc();



//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapGrpcService<DiscountService>();

//    endpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
//    });
//});