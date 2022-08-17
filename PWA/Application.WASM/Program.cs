using Application.WASM;
using Application.WASM.Repository;
using Application.WASM.Repository.Interface;
using Application.WASM.Services;
using Blazored.LocalStorage;
using IndexedDB.Blazor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Polly;
using Polly.Extensions.Http;
using Serilog;
using System;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddHttpClient<IUserService, UserService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
builder.Services.AddHttpClient<IGameService, GameService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
builder.Services.AddHttpClient<IChatService, ChatService>(c =>
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]));
builder.Services.AddScoped<HubConnect>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();

//.AddHttpMessageHandler<LoggingDelegatingHandler>()
//.AddPolicyHandler(GetRetryPolicy())
//.AddPolicyHandler(GetCircuitBreakerPolicy());
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton<IIndexedDbFactory, IndexedDbFactory>();
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
 


//static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
//{
//    // In this case will wait for
//    //  2 ^ 1 = 2 seconds then
//    //  2 ^ 2 = 4 seconds then
//    //  2 ^ 3 = 8 seconds then
//    //  2 ^ 4 = 16 seconds then
//    //  2 ^ 5 = 32 seconds

//    return HttpPolicyExtensions
//        .HandleTransientHttpError()
//        .WaitAndRetryAsync(
//            retryCount: 5,
//            sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
//            onRetry: (exception, retryCount, context) =>
//            {
//                Log.Error($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
//            });
//} static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
//{
//    return HttpPolicyExtensions
//        .HandleTransientHttpError()
//        .CircuitBreakerAsync(
//            handledEventsAllowedBeforeBreaking: 5,
//            durationOfBreak: TimeSpan.FromSeconds(30)
//        );
//}