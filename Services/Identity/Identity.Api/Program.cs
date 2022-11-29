using Common.Services.Exceptions;
using Identity.Api.Utilities;
using Identity.Application;
using Identity.Infrastructure;
using Identity.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddDbContext<IdentityDBContext>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<NotFoundExceptionFilterAttribute>();
    options.Filters.Add<BadRequestExceptionFilterAttribute>();
});
builder.Services.AddAuthentication(options =>
             {
                 options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                 options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                
             })
              .AddJwtBearer(cfg =>
              {
                
                  cfg.RequireHttpsMetadata = true;
                  cfg.SaveToken = true;
                  cfg.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                  {
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("OurUserIdentityService")),
                      ValidateAudience = false,
                      ValidateIssuer = false,
                      ValidateLifetime = false,
                      RequireExpirationTime = false,
                      ClockSkew = TimeSpan.Zero,
                      ValidateIssuerSigningKey = true
                      
                  };
              });
builder.Services.AddScoped<ITokenService, TokenService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
