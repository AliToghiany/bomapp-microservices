
using Chat.Application;
using Chat.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure;
using Chat.API.Data;
using Microsoft.EntityFrameworkCore;
using Chat.API.Hubs;
using Microsoft.AspNetCore.Builder;
using Chat.API.Respositories.Interface;
using Chat.API.Respositories;
using Chat.Application.Contracts.EndPoint;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddScoped<HubDbContext>(p => new HubDbContext(builder.Configuration));
builder.Services.AddSignalR();
builder.Services.AddScoped<IHubRepository, HubRepository>();
builder.Services.AddScoped<IReciveHub, ReciveHub>();
builder.Services.AddScoped<ReciveHub>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

})
              .AddJwtBearer(cfg =>
              {

                  cfg.RequireHttpsMetadata = true;
                  cfg.SaveToken = true;
                  cfg.Events = new JwtBearerEvents
                  {
                      OnMessageReceived = context =>
                      {
                          var acssesToken = context.Request.Query["access_token"];
                          if (string.IsNullOrEmpty(acssesToken) == false)
                          {
                              context.Token = acssesToken;
                          }
                          return Task.CompletedTask;
                      }

                  };
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
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
app.UseCors(x => x
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true) // allow any origin
          .AllowCredentials());
app.MapHub<ReciveHub>("reciveHub");
app.MapControllers();
app.UseStaticFiles();
app.Run();
