using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using WebAppApiGW.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
     .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
     .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHttpClient<IUserService, UserService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:IdentityApi"]));
builder.Services.AddHttpClient<IGroupSerivce,GroupSerivce>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:IdentityApi"]));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var maso = "CorsPolicy";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: maso, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}
app.UseCors(maso);
app.UseOcelot().Wait();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
