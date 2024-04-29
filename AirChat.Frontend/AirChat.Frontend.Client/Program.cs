using AirChat.ServiceClient.AirChat.API.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
var client = new AirChatServiceClient(new HttpClient { BaseAddress = new Uri("https://localhost:7155") });
builder.Services.AddSingleton(client);

await builder.Build().RunAsync();
