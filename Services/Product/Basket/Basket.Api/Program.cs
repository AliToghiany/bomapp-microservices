using Basket.Api.Repositories;
using Basket.Api.Repositories.Interface;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(options => { options.Configuration =builder.Configuration.GetValue<string>("CacheSettings:ConnectionString"); });
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
//builder.Services.AddMassTransit(config =>
//{
//    config.UsingRabbitMq((ctx, cfg) => {
//        cfg.Host(builder.Configuration["EventBusSettings:HostAddress"]);
//    });
//});


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
